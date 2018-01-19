using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Asteroid_game
{
    class SplashScreen: Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static List<BaseObject> _list;
        static SplashScreen()
        {
        }


        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();// Создаём объект - поверхность рисования и связываем его с формой
                                      // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            // Связываем буфер в памяти с графическим объектом.
            // для того, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            form.BackgroundImage = Image.FromFile(@"C:\Users\11\source\repos\Asteroid_game\Asteroid_game\img\Space.png");
            //SplashScreen.Load();
            //Timer timer = new Timer { Interval = 100 };
            //timer.Start();
            //timer.Tick += Timer_Tick;
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {

            //Draw();
           // Update();
        }
        public static void Load()
        {
           // Random random = new Random();
           // for (int i = 0; i < 30; i++) _list.Add(new Star(new Point(random.Next(0, Width), random.Next(0, Height)), new Point(i + 1, 0), new Size(15, 15)));
        }
    }
}
