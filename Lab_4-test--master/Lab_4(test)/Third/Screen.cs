using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_4_test_
{
    public class Screen
    {
        public Size Size { get; set; }
        public RectangleF Rectangle { get; set; }
        public Screen(Size sz, RectangleF r)
        {
            Size = sz;
            Rectangle = r;
        }
        public Point Convert(Vector3 v)
        {
            float x = (v.X - Rectangle.X) / Rectangle.Width * Size.Width;
            float y = (-Rectangle.Y + v.Y) / Rectangle.Height * Size.Height;
            return new Point((int)x,(int)y);
        }
        public float XX(int I)
        {
            return Rectangle.X + I * Rectangle.X / Rectangle.Width;
        }

        public float YY(int J)
        {
            return Rectangle.Y + (J - Rectangle.Height) * Rectangle.Y / (-Rectangle.Height);
        }
    }
}
