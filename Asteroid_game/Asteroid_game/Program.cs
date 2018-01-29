using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Asteroid_game
{
    static class Program
    {
        public static Form form;
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
            form = new Form();
            //using (StreamWriter sw = new StreamWriter(@"...\log.txt"))
            //    sw.WriteLine("");
            Application.Run(form1);
        }
    }
}
