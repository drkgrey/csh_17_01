using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Asteroid_game
{
    class Star:BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }        public override void Draw()
        {
            Image image = Properties.Resources.star;
            Game.Buffer.Graphics.DrawImage(image,Pos.X,Pos.Y,Size.Width,Size.Height);
          
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width - Size.Width;
        }
    }
}
