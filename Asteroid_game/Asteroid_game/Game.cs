using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using static System.Console;
using System.Resources;

namespace Asteroid_game
{
    internal class Game
    {
        public delegate void ConsoleHandler(object sender, ConsoleWritelineEventArgs e);
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        public static List<BaseObject> _list;
        private static List<Asteroid> _asteroids;
        private static Healpack _heal;
        private static Ship _ship = new Ship(new Point(10, 400), new Point(7, 7), new Size(20, 15));
        private static Timer _timer = new Timer();
        public static Random Rnd = new Random();
        private static List<Bullet> _bullets = new List<Bullet>();
        private static int NumberOfAsteroids = 5;
        private static bool gameOver = false;
        public static int Width { get; set; }
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
            Ship.MessageDie += Finish;
            Ship.LogCrush += ConsoleLog;
            Bullet.LogDestroed += ConsoleLog;
            Healpack.LogHeals += ConsoleLog;
            Ship.LogCrush += FileLog;
            Bullet.LogDestroed += FileLog;
            Healpack.LogHeals += FileLog;
        }
        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60,
            FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Graphics.DrawString("нажмите space чтобы начать заново", new Font(FontFamily.GenericSansSerif, 15), Brushes.White, 200, 200);
            Buffer.Graphics.DrawString("нажмите esc чтобы выйти", new Font(FontFamily.GenericSansSerif, 15), Brushes.White, 200, 250);
            Buffer.Render();
            if (_ship.Score >SplashScreen.score)
            {
                using (FileStream fcreate = File.Open(@"..\..\test.txt", FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fcreate))
                    {
                        sw.WriteLine(_ship.Score);
                    }
                }
            }
            gameOver = true;
            
        }
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey && _ship.Ammo>0)
            {
                if (e.KeyCode == Keys.ControlKey) _bullets.Add(new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y +
                4), new Point(4, 0), new Size(4, 1)));
                _ship.AmmoLow();
            }
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
            if (e.KeyCode == Keys.Right) _ship.Right();
            if (e.KeyCode == Keys.Left) _ship.Left();
            if (e.KeyCode == Keys.Space && gameOver) Application.Restart();
            if (e.KeyCode == Keys.Escape && gameOver) Application.ExitThread();
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
            foreach (Bullet b in _bullets) b.Draw();
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
            foreach (Bullet b in _bullets) b.Update();
            _heal?.Update();
            var a = 0;
            for (var i = 0; i < _asteroids.Count; i++)
            {
                if (_asteroids[i] == null)  continue; 
                _asteroids[i].Update();
                for (int j = 0; j < _bullets.Count; j++)
                {
                    if (_asteroids[i] != null && _bullets[j].Collision(_asteroids[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        _asteroids[i].Power--;
                        if (_asteroids[i].Power == 0) _asteroids[i] = null;
                        _bullets?.RemoveAt(j);
                        _ship?.AmmoUp();
                        _ship?.ScoreUp();
                        j--;
                    }
                    else if (_bullets[j].FlyAway()) { _bullets.RemoveAt(j); _ship.AmmoUp(); }
                }
                if (_asteroids[i] == null || !_ship.Collision(_asteroids[i])) continue;
                _ship?.EnergyLow(Rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                _ship.Crush();
                if (_ship.Energy <= 0) _ship?.Die(); 
            }
            if (_heal != null && _ship.Collision(_heal))
            {
                _heal.Heals();
                _ship?.EnergyLow(-10);
                _heal = null;
            }
            if (_asteroids.All(x => x == null)) { NumberOfAsteroids++; AsteroidsCreate(Rnd, NumberOfAsteroids); }
            if (_ship.Score %5==0) { _heal = new Healpack(new Point(Width, Rnd.Next(0, Height)), new Point(2, 5), new Size(10, 10));
            if (NumberOfAsteroids%10==0) { _asteroids.Add(new Asteroid(new Point(Width, 100), new Point(2, -1), new Size(300, 300))); NumberOfAsteroids++; }
            }
        }
        public static void Load()
        {
            StarCreate(Rnd);
            AsteroidsCreate(Rnd, NumberOfAsteroids);
           
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
        private static void AsteroidsCreate(Random random,int Number)
        {
            _asteroids = new List<Asteroid>();
            for (var i = 0; i < Number; i++)
            {
                int r = random.Next(15, 40);
                _asteroids.Add(new Asteroid(new Point(Width, random.Next(0, Height)), new Point(-200/(r*2), 150/(r*3)), new Size(r, r)));
            }
        }
    }
}
