using MechaDefense.Game.Enemies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace MechaDefense.Game
{
    public enum LevelState
    {
        Playing,
        Victory,
        Defeat
    }
    public class Level
    {
        public Map Map { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Bomb> Bombs { get; set; }
        public Player Player { get; set; }

        public Queue<(int Time, Enemy Enemy)> EnemyQueue { get; set; }
        public Queue<(int Time, Enemy Enemy)> EnemyQueueCopy { get; set; }
        public int FrameStart { get; set; }

        public LevelState State { get; set; }

        public Level()
        {
            State = LevelState.Playing;
            Map = new Map();
            Enemies = new List<Enemy>();
            Bombs = new List<Bomb>();
            EnemyQueue = new Queue<(int Time, Enemy Enemy)>();
            EnemyQueueCopy = new Queue<(int Time, Enemy Enemy)>();

            try
            {
                LoadLevel();
            }
            catch
            {
                throw new ApplicationException("Error during MapLoading");
            }

            Map.Data[0, 0].State = DeathState.Dying;
            Enemies.Add(new Burglar());
            Enemies[Enemies.Count - 1].Coords = new Point(8 * 64, 0);
            Enemies[Enemies.Count - 1].AttachedLevel = this;

            Player = new Player();
            Player.AttachedLevel = this;
            Player.Coords = new Point(Map.Width / 2 * Map.TileSize, Map.Height / 2 * Map.TileSize);

            FrameStart = GameController.CurrentFrame;

        }

        private void LoadLevel()
        {
            string rawMap = GameController.AssetLoader.MapData;
            StringReader reader = new StringReader(rawMap);

            string[] dimensionsStr = reader.ReadLine().Split(' ');
            int mapWidth = int.Parse(dimensionsStr[0]);
            int mapHeight = int.Parse(dimensionsStr[1]);

            if (mapWidth != Map.Width || mapHeight != Map.Height)
                throw new FormatException("Field has wrong dimensions");

            for (int i = 0; i < mapHeight; i++)
            {
                string[] mapLine = reader.ReadLine().Split(' ');
                for (int j = 0; j < mapWidth; j++)
                {
                    string obj = mapLine[j];

                    int objID = int.Parse(obj);
                    if (objID != 0)
                    {
                        Building building = GameController.ObjectsDb.Statics[objID]();
                        Map.Data[i, j] = building;
                        building.Coords = new Point(j * Map.TileSize, i * Map.TileSize);
                    }
                }
            }

            int enemyCount = int.Parse(reader.ReadLine());
            for (int i = 0; i < enemyCount; i++)
            {
                string[] enemyAppearDataStr = reader.ReadLine().Split(' ');

                int id = int.Parse(enemyAppearDataStr[0]);
                int column = int.Parse(enemyAppearDataStr[1]);
                int timingDeciSecs = int.Parse(enemyAppearDataStr[2]);

                (int Time, Enemy Enemy) record = (timingDeciSecs, GameController.ObjectsDb.Enemies[id]());
                EnemyQueue.Enqueue(record);
                EnemyQueueCopy.Enqueue(record);
                record.Enemy.Coords = new Point(column * Map.TileSize, 0);
                record.Enemy.AttachedLevel = this;

            }
        }

        public void Update(Graphics graphics)
        {
            UpdateObjects(graphics);
            UpdateMap(graphics);
            UpdatePlayerRelated(graphics);

            if (State == LevelState.Playing)
            {
                CheckDefeat();
                CheckVictory();
            }
        }

        private void UpdateMap(Graphics graphics)
        {
            for (int i = 0; i < Map.Height; i++)
            {
                for (int j = Map.Width - 1; j >= 0; j--)
                {
                    if(Map.Data[i,j]?.State == DeathState.Dead)
                        Map.Data[i, j] = null;

                    Map.Data[i, j]?.Draw(graphics);
                }
            }
        }

        private int DistanceCompare(Dynamic a, Dynamic b)
        {
            return a.Coords.Y - b.Coords.Y;
        }

        private void UpdateObjects(Graphics graphics)
        {
            ReleaseEnemies();

            Enemies.Sort(DistanceCompare);
            List<Enemy> deadEnemies = new List<Enemy>();
            foreach (Enemy enemy in Enemies)
            {
                enemy.Update();
                if (enemy.State == DeathState.Dead)
                {
                    deadEnemies.Add(enemy);
                    continue;
                }
                enemy.Draw(graphics);
            }
            foreach (Enemy deadEnemy in deadEnemies)
                Enemies.Remove(deadEnemy);
        }

        public void UpdatePlayerRelated(Graphics graphics)
        {
            Bombs.Sort(DistanceCompare);
            List<Bomb> deadBombs = new List<Bomb>();
            foreach (Bomb bomb in Bombs)
            {
                bomb.Update();
                if (bomb.State == DeathState.Dead)
                {
                    deadBombs.Add(bomb);
                    continue;
                }
                bomb.Draw(graphics);
            }
            foreach (Bomb deadBomb in deadBombs)
                Bombs.Remove(deadBomb);

            Player.Update();
            Player.Draw(graphics);
        }

        public void ReleaseEnemies()
        {
            if (EnemyQueue.Count == 0)
            {
                if (GameController.Settings.IsLooped)
                {
                    foreach((int Time, Enemy Enemy) enemy in EnemyQueueCopy)
                        EnemyQueue.Enqueue(enemy);
                }
                else
                {
                    return;
                }
            }

            if(EnemyQueue.Peek().Time <= (GameController.CurrentFrame - FrameStart)
                / (float)GameController.Settings.FPS)
            {
                Enemy enemy = EnemyQueue.Dequeue().Enemy;
                enemy.AttachedLevel = this;
                Enemies.Add(enemy);
            }
        }

        private void CheckVictory()
        {
            if(Enemies.Count == 0 && EnemyQueue.Count == 0)
            {
                State = LevelState.Victory;
                foreach (Enemy enemy in Enemies)
                {
                    enemy.CurrentSpeed = new Point(0, 0);
                    enemy.State = DeathState.Dying;
                }
            }

        }

        private void CheckDefeat()
        {
            int powerPlantsCount = 0;
            foreach (Building build in Map.Data)
                if (build is PowerPlant)
                    powerPlantsCount++;

            bool hasEnemyEscaped = false;
            foreach (Enemy enemy in Enemies)
                if (enemy.Coords.Y > GameController.Settings.Resolution.Y)
                    hasEnemyEscaped = true;

            if (powerPlantsCount == 0 || hasEnemyEscaped)
            {
                State = LevelState.Defeat;

                foreach (Enemy enemy in Enemies)
                    enemy.CurrentSpeed = new Point(0, 0);

                foreach (Building building in Map.Data)
                    if (building != null && building.ObjectID > 2)
                        building.State = DeathState.Dying;
            }

        }
    }
}
