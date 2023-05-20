using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense.GUI
{
    public class GameButtonToggle : GameButton
    {
        public bool IsToggled { get; protected set; }

        public Image ToggledImage { get; }
        public GameButtonToggle(Point coords, Point size, Image pic, Image picToggled, ButtonAction pAction) : 
            base(coords, size, pic, pAction)
        {
            ToggledImage = picToggled;
            IsToggled = false;
        }

        public override void Press()
        {
            base.Press();
            IsToggled = !IsToggled;
        }

        public override void Draw(Graphics graphics)
        {
            if (IsToggled)
                graphics.DrawImage(ToggledImage, Coords);
            else
                graphics.DrawImage(Image, Coords);
        }


    }
}
