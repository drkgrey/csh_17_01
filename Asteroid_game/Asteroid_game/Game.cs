using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using static System.Console;

namespace Asteroid_game
{
    internal class Game
    {
        public delegate void ConsoleHandler(object sender, ConsoleWritelineEventArgs e);
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        public static List<BaseObject> _list;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;
        private static Healpack _heal;
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 7), new Size(20, 15));        private static Timer _timer = new Timer();
        public static Random Rnd = new Random();          public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }
       
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            if (Width > 1000 || Height > 1000 || Width < 0 || Height < 0) throw new ArgumentOutOfRangeException();
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            _timer = new Timer { Interval = 10 };
            _timer.Start();
            _timer.Tick += Timer_Tick;
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;            Ship.LogCrush += ConsoleLog;            Bullet.LogDestroed += ConsoleLog;            Healpack.LogHeals += ConsoleLog;            Ship.LogCrush += FileLog;            Bullet.LogDestroed += FileLog;            Healpack.LogHeals += FileLog;        }

        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60,
            FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4),
                new Point(4, 0), new Size(4, 1));
            }
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
            if (e.KeyCode == Keys.Right) _ship.Right();
            if (e.KeyCode == Keys.Left) _ship.Left();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }


        private static void ConsoleLog(object sender, ConsoleWritelineEventArgs e)
        {
            WriteLine(e.Message);
        }
        private static void FileLog(object sender, ConsoleWritelineEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("C:/Users/11/csh_17_01/Asteroid_game/Asteroid_game/log.txt",true,Encoding.Default)) 
            sw.WriteLine(e.Message);
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _list)
                obj?.Draw();
            foreach (BaseObject obj in _objs)
                obj?.Draw();
            foreach (Asteroid obj in _asteroids)
                obj?.Draw();
            _bullet?.Draw();
            _ship?.Draw();
            _heal?.Draw();
            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0,
                0);
                Buffer.Graphics.DrawString("Score:" + _ship.Score, SystemFonts.DefaultFont, Brushes.White, 100,
                0);
            }
            Buffer.Render();
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
               obj?.Update();
            foreach (BaseObject obj in _list)
                obj?.Update();
            _heal?.Update();
            _bullet?.Update();
            var a = 0;
            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) { a++; continue; }
                _asteroids[i].Update();
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    _bullet.Destroed();
                    System.Media.SystemSounds.Hand.Play();
                        _asteroids[i] = null;
                        _bullet = null;
                      //_ship?.AmmoUp();
                        _ship?.ScoreUp();
                            
                        continue;
                }
                if (!_ship.Collision(_asteroids[i])) continue;
                _ship?.EnergyLow(Rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                _ship.Crush();
                if (_ship.Energy <= 0) _ship?.Die();
            }            if (_heal != null && _ship.Collision(_heal))
            {
                _heal.Heals();
                _ship?.EnergyLow(-10);
                _heal = null;
            }
            if (_ship.Score %5==0) { _heal = new Healpack(new Point(Width, Rnd.Next(0, Height)), new Point(2, 5), new Size(10, 10)); }
            if (a == 10) {
                AsteroidsCreate(Rnd);
            }        }

        public static void Load()
        {
            StarCreate(Rnd);
            AsteroidsCreate(Rnd);
        }

        private static void StarCreate(Random random)
        {
            _list = new List<BaseObject>();
            _objs = new BaseObject[40];
            for (var i = 0; i < _objs.Length; i++)
            {
                int r = random.Next(5, 50);
                _objs[i] = new Star(new Point(random.Next(0, Width), random.Next(0, Height)), new Point(-r, r), new Size(3, 3));
            }
            _list.Add(new Planet(new Point(random.Next(0, Width), random.Next(0, Height - 200)), new Point(2, 0), new Size(100, 100)));
            _list.Add(new Dstar(new Point(random.Next(0, Width), random.Next(0, Height)), new Point(5, 5), new Size(100, 100)));
        }

        private static void AsteroidsCreate(Random random)
        {
            _asteroids = new Asteroid[10];
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = random.Next(5, 30);
                _asteroids[i] = new Asteroid(new Point(Width, random.Next(0, Height)), new Point(-r / 5, r), new Size(r, r));
            }
        }
    }
}
