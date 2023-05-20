using MechaDefense.Game;
using MechaDefense.Game.Enemies;
using MechaDefense.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MechaDefense
{
    public static class GameController
    {
        public static int CurrentFrame { get; set; } = 0;
        public static Settings Settings { get; set; }
        public static ButtonsController ButtonsController { get; set; }
        public static AssetLoader AssetLoader { get; set; }
        public static GameForm Form { get; set; }

        public static ObjectsDb ObjectsDb { get; set; }
        public static AnimationBank AnimationBank { get; set; }

        public static Level Level { get; set; }


        public static Image Background { get; set; }
        public static Point MousePos { get; set; }

        static GameController()
        {
            Settings = new Settings();
            ButtonsController = new ButtonsController();
            AssetLoader = new AssetLoader();
            AnimationBank = new AnimationBank();
            ObjectsDb = new ObjectsDb();
        }

        public static void ConnectForm(GameForm form)
        {
            Form = form;
            Form.ClientSize = (Size)Settings.Resolution;
        }

        public static void Update(Graphics graphics)
        {
            if (Background != null)
                graphics.DrawImage(Background, new Point(0, 0));

            Level?.Update(graphics);
            DrawUI(graphics);

            CurrentFrame++;
        }

        private static void DrawUI(Graphics graphics)
        {
            switch(Level?.State)
            {
                case LevelState.Victory:
                    graphics.DrawImage(AssetLoader.Assets["victory.png"], new Point(363, 287));
                    break;
                case LevelState.Defeat:
                    graphics.DrawImage(AssetLoader.Assets["defeat.png"], new Point(363, 287));
                    break;
                case null:
                    foreach (GameButton button in ButtonsController.GetAll())
                        button.Draw(graphics);
                    break;
            }
        }

        public static void InitGameLoop()
        {
            Form.LoopTimer.Interval = 1000 / Settings.FPS;
            Form.LoopTimer.Tick += (object sender, EventArgs e) => Form.Refresh();
            Form.LoopTimer.Start();
        }

        public static void Start()
        {
            Menu menu = new Menu();
            menu.OpenMenu();
            InitGameLoop();
        }

        public static bool IsNthFrame(int frame)
        {
            return CurrentFrame % frame == 0;
        }

    }
}
