using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Asteroid_game
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        public static List<BaseObject> _list;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
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
            Game.Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }


        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _list)
                obj.Draw();
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (BaseObject obj in _list)
                obj.Update();
        }

        public static void Load()
        {
            Random random = new Random();
            _list = new List<BaseObject>();
            for (int i = 0; i < 3; i++) _list.Add(new Planet(new Point(random.Next(0, Width), random.Next(0, Height)), new Point(i+1, i+2), new Size(60, 60)));
            for (int i = 0; i < 4; i++) _list.Add(new Planet(new Point(random.Next(0, Width), random.Next(0, Height)), new Point(-i*2+ 1, i + 2), new Size(50, 50)));
            for (int i = 0; i < 30; i++) _list.Add(new Star(new Point(random.Next(0,Width), random.Next(0, Height)), new Point(i+1, 0), new Size(15,15)));
            _list.Add(new Dstar(new Point(random.Next(0, Width), random.Next(0, Height)), new Point(1, 1), new Size(100, 100)));
            _objs = new BaseObject[40];
            for (int i = 0; i < _objs.Length ; i++)
                _objs[i] = new BaseObject(new Point(random.Next(0, Width), random.Next(0, Height)), new Point(i+1, -i), new Size(5, 5));
           
           
        }

    }
}
