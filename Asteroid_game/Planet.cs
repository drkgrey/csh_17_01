using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroid_game
{
    class Planet:BaseObject
    {
        protected int n;
        protected List<Image> list;
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            n = 0;
            list = new List<Image>();
            list.Add(Properties.Resources.avatan);
            list.Add(Properties.Resources.planet);
            list.Add(Properties.Resources.mars);
            list.Add(Properties.Resources.Neptune);
            list.Add(Properties.Resources.moon);
          
        }
        
        public override void Draw()
        {            
            
            Game.Buffer.Graphics.DrawImage(list.ElementAt(n), Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < -Size.Width)
            {
                n++;
                Pos.X = Game.Width ;
                if (n == 4) n = 0;
            }
        }
    }
}
