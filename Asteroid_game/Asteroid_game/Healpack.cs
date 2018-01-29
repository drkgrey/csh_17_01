using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroid_game
{
    class Healpack:BaseObject
    {
        public static event ConsoleHandler LogHeals;
        public Healpack(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw() => Game.Buffer.Graphics.DrawImage(Properties.Resources.heal, Pos.X, Pos.Y, Size.Width, Size.Height);
        public override void Update() => Pos.X = Pos.X - 5;
        public void Heals() => LogHeals?.Invoke(this, new ConsoleWritelineEventArgs("поймана аптечка"));

    }
}
