using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense
{
    public enum BuildingIdName
    {
        GreenForest = 1,
        Stone = 2,
        HangarOrange = 3,
        HangarGreen = 4,
        Factory = 5,
        PowerPlant = 6,
        Radar = 7
    }

    public class Building : GameObject, IDrawable
    {
        public Image Sprite;
        public Building(int durability) : base()
        {
            Durability = durability;
        }

        public void Draw(Graphics graphics)
        {
            if (State == DeathState.Alive)
            {
                Point coords = Coords;
                if (Sprite.Height > 64)
                    coords = new Point(coords.X, coords.Y - 64);

                graphics.DrawImage(Sprite, coords);
            }
            else if(State == DeathState.Dying)
            {
                bool isLastFrame;
                Image sprite = DeathAnimation.InterpolateAndGetFrame(GameController.CurrentFrame, out isLastFrame);
                graphics.DrawImage(sprite, Coords);
                if (isLastFrame)
                    State = DeathState.Dead;

            }
        }
    }
}
