using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.Close();

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
