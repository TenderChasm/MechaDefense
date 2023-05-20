using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense.GUI
{
    class GameButtonToggleBind : GameButtonToggle
    {
        public List<GameButtonToggleBind> BindedButtons { get; set; }

        public GameButtonToggleBind(Point coords, Point size, Image pic, Image picToggled, ButtonAction pAction) :
            base(coords, size, pic, picToggled, pAction)
        {
            BindedButtons = new List<GameButtonToggleBind>();
        }

        public override void Press()
        {
            base.Press();
            IsToggled = true;
            foreach (GameButtonToggleBind button in BindedButtons)
                button.IsToggled = false;
        }
    }
}
