using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MechaDefense
{
    public class AssetLoader
    {
        private string assetFolder { get; }  =  "Resources";
        private string mapFileName { get; } = "Map.ego";
        public Dictionary<string, Image> Assets { get; set; }

        public string MapData { get; set; }

        public AssetLoader()
        {
            Assets = new Dictionary<string, Image>();
            Load(assetFolder);
            LoadRawMap(mapFileName);
        }

        private void Load(string folderPath)
        {
            string[] dirsToParse = Directory.GetDirectories(folderPath);
            string[] files = Directory.GetFiles(folderPath);

            foreach (string file in files)
                Assets.Add(file.Substring(file.IndexOf('\\') + 1), Image.FromFile(file));

            foreach (string dir in dirsToParse)
                Load(dir);
        }

        private void LoadRawMap(string filePath)
        {
            MapData = File.ReadAllText(filePath);
        }
    }
}
