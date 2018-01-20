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
            SplashScreenForm form1 = new SplashScreenForm();
            SplashScreen.Init(form1);
            form1.Show();
            
           
            Application.Run(form1);
            //Application.Run(form);
        }
    }
}
