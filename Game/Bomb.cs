using MechaDefense.Game.Enemies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense.Game
{
    public class Bomb : Dynamic
    {
        public int Radius { get; set; } = 32;
        public Bomb(Point coords) : base(1, 0, new Animation(GameController.AnimationBank.BombExplosion))
        {
            DeathAnimation = MoveAnimation;
            Coords = coords;
            MeleeDPS = 2;
            State = DeathState.Dying;
        }

        public override void Update()
        {
            Point currentTile = new Point(Coords.X / AttachedLevel.Map.TileSize, Coords.Y / AttachedLevel.Map.TileSize);
            Building tile = AttachedLevel.Map.Data[currentTile.Y, currentTile.X];
            if (tile != null && tile.ObjectID < 3)
                tile.Durability -= MeleeDPS;
            
            foreach(Enemy enemy in AttachedLevel.Enemies)
            {
                Point centerCoords = AverageCenterCoords;
                Point centerEnemy = enemy.AverageCenterCoords;
                PointF vector = new PointF(centerEnemy.X - centerCoords.X, centerEnemy.Y - centerCoords.Y);
                float length = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
                if (length <= Radius)
                    enemy.Durability -= MeleeDPS;
            }
        }
    }
}
