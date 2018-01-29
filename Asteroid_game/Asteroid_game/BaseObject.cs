using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroid_game
{
     abstract class BaseObject: ICollision
    {
        public delegate void Message();
        public delegate void ConsoleHandler(object sender, ConsoleWritelineEventArgs e);
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            if (Dir.X > 60 || Dir.Y > 60) throw new GameException("слишком большая скорость объекта");
            if(Size.Width < 0 || Size.Height < 0 || Size.Width > 300 || Size.Height > 300)
                throw new GameException("некоректные размеры объекта");
        }
        public abstract void Draw();
        public abstract void Update();
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);

    }
}
