using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroid_game
{
    class Dot
    {
        protected SolidBrush brush;
        protected Point Pos;
        protected Size Size;
        protected static List<Color> color;
        protected static int i ;
        public static void Set()
        {
            color = new List<Color>();
            color.Add(Color.Aqua);
            color.Add(Color.DarkViolet);
            color.Add(Color.White);
        }

        public Dot(Point pos, Size size) 
        {

            Pos = pos;
            Size = size;
        }

        public virtual void Draw()
        {
            brush = new SolidBrush(color.ElementAt(i));
            SplashScreen.Buffer.Graphics.FillEllipse(brush, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public static void Update()
        {
            if (i < color.Count-1) i++;
            else i = 0;
        }
    }
}
