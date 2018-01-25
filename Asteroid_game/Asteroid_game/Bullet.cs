using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroid_game
{
    class Bullet:BaseObject
    {
        public static event ConsoleHandler LogDestroed;
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw() => Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        public override void Update() => Pos.X = Pos.X + 10;

        public void Collision() => Pos.X = 0;
        public bool FlyAway()
        {
            if (Pos.X >= Game.Width) return true;
            else return false;
        }
        public void Destroed() => LogDestroed?.Invoke(this, new ConsoleWritelineEventArgs("метеорит уничтожен"));
    }
}
