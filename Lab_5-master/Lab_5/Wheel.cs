using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
   public class Wheel
    {
        public float Radius { get; set; }
        public Vector2 Center { get; set; }
        public bool Special;  // колесо, на которое действует внешняя сила

        public Wheel(float r,float x, float y, bool special)
        {
            Radius = r;
            Center = new Vector2(x,y);
            Special = special;
        }
    }
}
