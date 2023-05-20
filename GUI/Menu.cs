using MechaDefense.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense.GUI
{
    public class Menu
    {
        public void OpenMenu()
        {
            GameController.ButtonsController.Flush();
            AddLoadedButton("buttons\\playButton.png", new Point(363, 188), PlayButtonAction);
            AddLoadedButton("buttons\\optionsButton.png", new Point(363, 287), OptionsButtonAction);
            AddLoadedButton("buttons\\exitButton.png", new Point(363, 386), ExitButtonAction);

            GameController.Background = GameController.AssetLoader.Assets["backgrounds\\MenuScreen.png"];
        }

        public void OpenOptions()
        {
            GameController.ButtonsController.Flush();

            GameButtonToggleBind easyButton = AddLoadedButtonToggleBind("buttons\\easyButton.png", 
                "buttons\\easyButtonToggle.png", new Point(516, 188), () => SelectDifficulty(Settings.Difficulty.Easy));

            GameButtonToggleBind normalButton = AddLoadedButtonToggleBind("buttons\\normalButton.png",
                "buttons\\normalButtonToggle.png", new Point(516, 287), () => SelectDifficulty(Settings.Difficulty.Normal));

            GameButtonToggleBind hardButton = AddLoadedButtonToggleBind("buttons\\hardButton.png", 
                "buttons\\hardButtonToggle.png", new Point(516, 386), () => SelectDifficulty(Settings.Difficulty.Hard));

            GameButtonToggleBind yellowButton = AddLoadedButtonToggleBind("buttons\\yellowButton.png", 
                "buttons\\yellowButtonToggle.png", new Point(210, 188), () => SelectColor(Settings.ShipColor.Yellow));

            GameButtonToggleBind redButton = AddLoadedButtonToggleBind("buttons\\redButton.png", 
                "buttons\\redButtonToggle.png", new Point(210, 287), () => SelectColor(Settings.ShipColor.Red));

            easyButton.BindedButtons = new List<GameButtonToggleBind>() { normalButton, hardButton };
            normalButton.BindedButtons = new List<GameButtonToggleBind>() { easyButton, hardButton };
            hardButton.BindedButtons = new List<GameButtonToggleBind>() { normalButton, easyButton };
            yellowButton.BindedButtons = new List<GameButtonToggleBind>() { redButton};
            redButton.BindedButtons = new List<GameButtonToggleBind>() { yellowButton};

            switch(GameController.Settings.CurrentDifficulty)
            {
                case Settings.Difficulty.Easy:
                    easyButton.Press();
                    break;
                case Settings.Difficulty.Normal:
                    normalButton.Press();
                    break;
                case Settings.Difficulty.Hard:
                    hardButton.Press();
                    break;
            }

            switch(GameController.Settings.CurrentColor)
            {
                case Settings.ShipColor.Red:
                    redButton.Press();
                    break;
                case Settings.ShipColor.Yellow:
                    yellowButton.Press();
                    break;
            }

            AddLoadedButton("buttons\\loopButton.png", new Point(210, 386),
                () => GameController.Settings.IsLooped = !GameController.Settings.IsLooped);
            AddLoadedButton("buttons\\exitButton.png", new Point(363, 485), () => OpenMenu());

        }

        private void AddLoadedButton(string path, Point point, ButtonAction action)
        {
            Image buttonImage = GameController.AssetLoader.Assets[path];
            GameButton button =
                new GameButton(point, (Point)buttonImage.Size, buttonImage, action);
            GameController.ButtonsController.Add(button);
        }

        private GameButtonToggle AddLoadedButtonToggle(string path, string pathToggled, Point point, ButtonAction action)
        {
            Image buttonImage = GameController.AssetLoader.Assets[path];
            Image buttonImageToggled = GameController.AssetLoader.Assets[pathToggled];
            GameButtonToggle button =
                new GameButtonToggle(point, (Point)buttonImage.Size, buttonImage, buttonImageToggled, action);
            GameController.ButtonsController.Add(button);
            return button;
        }

        private GameButtonToggleBind AddLoadedButtonToggleBind(string path, string pathToggled, Point point,
            ButtonAction action, List<GameButtonToggleBind> binded = null)
        {
            Image buttonImage = GameController.AssetLoader.Assets[path];
            Image buttonImageToggleBind = GameController.AssetLoader.Assets[pathToggled];
            GameButtonToggleBind button =
                new GameButtonToggleBind(point, (Point)buttonImage.Size, buttonImage, buttonImageToggleBind, action);
            GameController.ButtonsController.Add(button);
            button.BindedButtons = binded;
            return button;
        }

        void SelectDifficulty(Settings.Difficulty diff)
        {
            GameController.Settings.CurrentDifficulty = diff;
        }

        void SelectColor(Settings.ShipColor color)
        {
            GameController.Settings.CurrentColor = color;
        }

        private void PlayButtonAction()
        {
            GameController.ButtonsController.Flush();
            GameController.Background = GameController.AssetLoader.Assets["backgrounds\\background.png"];
            GameController.Level = new Level();
        }

        private void OptionsButtonAction()
        {
            OpenOptions();
        }

        private void ExitButtonAction()
        {
            GameController.Form.Close();
        }
    }
}
