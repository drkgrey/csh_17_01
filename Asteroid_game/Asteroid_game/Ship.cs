using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroid_game
{
    class Ship: BaseObject
    {
        public static event Message MessageDie;
        public static event ConsoleHandler LogCrush;
        private int _energy = 100;
        public int Energy => _energy;
        private int _score = 0;
        public int Score => _score;
        private int _ammo = 5;
        public int Ammo => _ammo;

        public void AmmoLow() => _ammo--;
        public void AmmoUp() => _ammo++;
        public void EnergyLow(int n) => _energy -= n;
        public void ScoreUp() => _score++;
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw() => Game.Buffer.Graphics.DrawImage(Properties.Resources.ship, Pos.X, Pos.Y, Size.Width, Size.Height);
        public override void Update()
        {
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Left()
        {
            if (Pos.X > 0) Pos.X = Pos.X - Dir.X;
        }
        public void Right()
        {
            if (Pos.X < Game.Width) Pos.X = Pos.X + Dir.X;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }
        public void Die() => MessageDie?.Invoke();
        public void Crush() => LogCrush?.Invoke(this, new ConsoleWritelineEventArgs("столкновение с метеоритом"));

    }
}
