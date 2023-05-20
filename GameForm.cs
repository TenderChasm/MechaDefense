using MechaDefense.GUI;
using MechaDefense.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MechaDefense
{
    public partial class GameForm : Form
    {
        public Graphics Graphics;
        public GameForm()
        {
            InitializeComponent();
            Graphics = CreateGraphics();
            GameController.ConnectForm(this);
            GameController.Start();
        }

        private void GameForm_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void GameForm_Load(object sender, EventArgs e)
        {
   
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            GameController.Update(e.Graphics);
        }

        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            GameController.ButtonsController.FindPressedButtonAndActivate(new Point(e.X, e.Y));
        }

        private void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            GameController.MousePos = new Point(e.X, e.Y);
        }
    }
}
