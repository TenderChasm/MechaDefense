using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechaDefense.Game
{
    public class Map
    {
        public int Width { get;}
        public int Height { get; }

        public int TileSize { get; }

        public Building[,] Data { get; set; }

        public Map()
        {
            TileSize = 64;
            Width = GameController.Settings.Resolution.X / TileSize;
            Height = GameController.Settings.Resolution.Y / TileSize;
            Data = new Building[Height + 1, Width];
        }


    }
}
