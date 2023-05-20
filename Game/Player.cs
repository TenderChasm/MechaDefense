using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense.Game
{
    public class Player : Dynamic
    {
        public int BombDropoutFrameCooldown {get; set;} = 7;

        public Player() : 
            base(
                    100,
                    3,
                    GameController.Settings.CurrentColor == Settings.ShipColor.Yellow ?
                        new Animation(GameController.AnimationBank.AnimationPerDynamicsId[(int)Settings.ShipColor.Yellow]) :
                        new Animation(GameController.AnimationBank.AnimationPerDynamicsId[(int)Settings.ShipColor.Red])
                )
        {
            MeleeDPS = 5;
        }

        public override void Update()
        {
            Point mousePos = GameController.MousePos;
            PointF directionVector = new PointF(mousePos.X - Coords.X, mousePos.Y - Coords.Y);
            float length = (float)Math.Sqrt(directionVector.X * directionVector.X + directionVector.Y * directionVector.Y);
            PointF directionVectorNormalized = new PointF(directionVector.X / length, directionVector.Y / length);
            PointF velocityVector = new PointF(directionVectorNormalized.X * Speed * AttachedLevel.Map.TileSize,
                directionVectorNormalized.Y * Speed * AttachedLevel.Map.TileSize);

            PointF newCoords = new PointF(Coords.X + velocityVector.X / GameController.Settings.FPS,
               Coords.Y + velocityVector.Y / GameController.Settings.FPS);

            if (newCoords.X > 0 && newCoords.X < GameController.Settings.Resolution.X &&
               newCoords.Y > 0 && newCoords.Y < GameController.Settings.Resolution.Y &&
               length > 12)
            {
                Coords = new Point((int)Math.Floor(newCoords.X), (int)Math.Floor(newCoords.Y));
            }

            if (GameController.IsNthFrame(BombDropoutFrameCooldown))
            {
                int tileSize = AttachedLevel.Map.TileSize;
                var rand = new Random();
                Point bombCoords = new Point(Coords.X + rand.Next(-(tileSize / 3), tileSize / 3),
                    Coords.Y + rand.Next(-(tileSize / 4), tileSize / 4));

                Bomb bomb = new Bomb(bombCoords);
                bomb.AttachedLevel = AttachedLevel;
                AttachedLevel.Bombs.Add(bomb);
            }
        }

    }
}
