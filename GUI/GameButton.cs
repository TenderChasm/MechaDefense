using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense.GUI
{
    public delegate void ButtonAction();

    public class GameButton : IMeasurable,IDrawable
    {
        public Point Coords { get; set; }
        public Point Size { get; set; }
        public Image Image { get; }

        protected ButtonAction action { get; set; }
        public GameButton(Point coords, Point size, Image pic, ButtonAction pAction)
        {
            action = pAction;
            Coords = coords;
            Image = pic;
            Size = size;
        }

        public virtual void Press()
        {
            action?.Invoke();
        }

        public bool IfPointInBorders(Point point)
        {
            return (point.X >= Coords.X && point.X <= Coords.X + Size.X) &&
               (point.Y >= Coords.Y && point.Y <= Coords.Y + Size.Y);
        }

        public virtual void Draw(Graphics graphics)
        {
            graphics.DrawImage(Image, Coords);
        }


    }
}
