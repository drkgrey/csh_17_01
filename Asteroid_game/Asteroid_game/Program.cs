using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroid_game
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // SplashScreenForm form1 = new SplashScreenForm();
            //SplashScreen.Init(form1);
            //form1.Show();
            //Form form = new Form()
            //{
            //    Width = Screen.PrimaryScreen.Bounds.Width,
            //    Height = Screen.PrimaryScreen.Bounds.Height
            //};
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            Game.Draw();
            form.Show();

            //Application.Run(form1);
            Application.Run(form);
        }
    }
}
