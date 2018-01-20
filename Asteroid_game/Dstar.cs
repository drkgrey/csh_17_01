using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Asteroid_game
{
    class Dstar:BaseObject
    {
        public Dstar(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Image image = Properties.Resources.Dstar;
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.X > Game.Width+Size.Width) Pos.X = -Size.Width;
            if (Pos.Y < -Size.Height) Pos.Y = Game.Height;
        }
    }
}
