using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Asteroid_game.Program;

namespace Asteroid_game
{
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();
            
        }

        private void Start_button_Click(object sender, EventArgs e)
        {
            Hide();
            form.Width = 800;
            form.Height = 600;
            form.Show();
            Game.Init(form);
            Game.Draw();
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void Record_button_Click(object sender, EventArgs e)
        {

        }
    }
}
