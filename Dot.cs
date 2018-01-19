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
        SolidBrush brush;
        private Point Pos;
        private Size Size;
        private static List<Color> color;
        private static int i ;


        public Dot(Point pos, Size size) 
        {
            color = new List<Color>();
            color.Add(Color.Aqua);
            color.Add(Color.DarkViolet);
            color.Add(Color.Gold);
        }

        public void Draw1()
        {
            brush = new SolidBrush(Color.Aqua);
            Game.Buffer.Graphics.FillEllipse(brush,Pos.X,Pos.Y, Size.Width, Size.Height);
        }
        public void Update1()
        {
            if (i < color.Count) i++;
            else i = 0;
        }
    }
}
