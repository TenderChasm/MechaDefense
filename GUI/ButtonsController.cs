using MechaDefense.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense
{
    public class ButtonsController
    {
        private static List<GameButton> buttons { get; set; }

        public ButtonsController()
        {
            buttons = new List<GameButton>();
        }

        public void Add(GameButton button)
        {
            buttons.Add(button);
        }

        public void Flush()
        {
            buttons.Clear();
        }

        public GameButton Get(GameButton button)
        {
            foreach(GameButton retButton in buttons)
                if(retButton == button)
                    return retButton;

            return null;
        }

        public List<GameButton> GetAll()
        {
            return buttons;
        }

        public GameButton GetPressedButton(Point point)
        {
            foreach (GameButton button in buttons)
                if (button.IfPointInBorders(point))
                    return button;

            return null;
        }

        public void FindPressedButtonAndActivate(Point point)
        {
            foreach (GameButton button in buttons)
            {
                if (button.IfPointInBorders(point))
                {
                    button.Press();
                    return;
                }
            }
        }
    }
}
