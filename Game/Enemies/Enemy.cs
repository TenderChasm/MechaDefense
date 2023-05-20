using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense.Game.Enemies
{
    public enum EnemyIdName : int
    {
        Burglar = 2,
        Viper = 3,
        Wasp = 4,
    }

    public abstract class Enemy : Dynamic
    {

        public Enemy(int durability, int speed, int meleeDamage, Animation moveAnimation) :
            base(durability, speed, moveAnimation)
        {
            MeleeDPS = meleeDamage;
            CurrentSpeed = new PointF(0, Speed);

        }
        public override void Update()
        {
            float passedDist = CurrentSpeed.Y * AttachedLevel.Map.TileSize / GameController.Settings.FPS;
            Point currentTile = new Point(Coords.X / AttachedLevel.Map.TileSize,
                (int)Math.Floor((Coords.Y + MoveAnimation.Data[0].Sprite.Size.Height * 0.75 + passedDist) / AttachedLevel.Map.TileSize));

            if(AttachedLevel.Map.Data[currentTile.Y, currentTile.X] != null)
            {
                AttachedLevel.Map.Data[currentTile.Y, currentTile.X].Durability -= MeleeDPS;
            }
            else
            {
                Coords = new Point(Coords.X, (int)Math.Round(Coords.Y + passedDist));
            }
        }


    }
}
