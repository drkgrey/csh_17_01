using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Asteroid_game
{
    internal class SplashScreen
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static List<Dot> _list;
        public static Timer timer;
        public static int score;
        public static bool show=false;
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
            Load();
            timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Load()
        {
            Random random = new Random();
            _list = new List<Dot>();
            Dot.Set();
            for (int i = 0; i < 10; i++) _list.Add(new Dot(new Point(random.Next(0, Width), random.Next(0, Height)), new Size(3,3)));
            for (int i = 0; i <10; i++) _list.Add(new Dot(new Point(random.Next(0, Width), random.Next(0, Height)), new Size(10, 10)));
            for (int i = 0; i < 10; i++) _list.Add(new Dot(new Point(random.Next(0, Width), random.Next(0, Height)), new Size(15, 15)));

        }
        public static void Draw()
        {
           Buffer.Graphics.Clear(Color.Empty);
           if(show) Buffer.Graphics.DrawString("highscore:" + score, SystemFonts.DefaultFont, Brushes.White, Width/2, 0);
            foreach (Dot obj in _list)
                obj.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
               Dot.Update();
        }
        public static void HighScore(string st)
        {
            if (!show) show = true; else show = false;
            score = Int32.Parse(st);
        }
    }
}
