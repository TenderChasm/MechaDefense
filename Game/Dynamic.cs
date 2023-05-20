using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense.Game
{
    public abstract class Dynamic : GameObject, IDrawable
    {
        public Animation MoveAnimation { get; set; }
        public Point AverageCenterCoords
        {
            get
            {
                return new Point(Coords.X + MoveAnimation.Data[0].Sprite.Width / 2,
                Coords.Y + MoveAnimation.Data[0].Sprite.Height / 2);
            }
        }

        public int MeleeDPS { get; set; }
        public int Speed { get; set; }
        public PointF CurrentSpeed { get; set; }

        public Level AttachedLevel { get; set; }

        public Dynamic(int durability, int speed, Animation moveAnimation) : base()
        {
            Speed = speed;
            Durability = durability;
            MoveAnimation = moveAnimation;
        }

        public void Draw(Graphics graphics)
        {
            if (State == DeathState.Alive)
            {
                bool isLastFrame;
                Image sprite = MoveAnimation.InterpolateAndGetFrame(GameController.CurrentFrame, out isLastFrame);
                graphics.DrawImage(sprite, Coords);
            }
            else
            {
                bool isLastFrame;
                Image sprite = DeathAnimation.InterpolateAndGetFrame(GameController.CurrentFrame, out isLastFrame);
                graphics.DrawImage(sprite, Coords);
                if (isLastFrame)
                    State = DeathState.Dead;

            }
        }
        public abstract void Update();
    }
}
