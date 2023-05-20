using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense
{
    public class Settings
    {
        public enum ShipColor
        {
            Yellow = 0,
            Red = 1,
        }

        public enum Difficulty
        {
            Easy,
            Normal,
            Hard
        }

        //defaults
        public Point Resolution { get; set; } = new Point(1024, 768);
        public int FPS { get; set; } = 30;
        public bool IsLooped { get; set; } = false;
        public ShipColor CurrentColor { get; set; } = ShipColor.Yellow;
        public Difficulty CurrentDifficulty { get; set; } = Difficulty.Easy;
    }
}
