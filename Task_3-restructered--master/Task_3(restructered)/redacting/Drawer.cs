using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_3_restructered_
{
   public class Drawer
    {
        public static Bitmap Draw(Bitmap bmp, Segment s, ScreenConverter conv)
       {    
            Graphics g = Graphics.FromImage(bmp);
                g.DrawArc(Pens.Black, conv.II(s.Center.X) - s.R, conv.JJ(s.Center.Y) - s.R,
                s.R * 2, s.R * 2, s.StartAngle, s.SweepAngle);
            g.DrawEllipse(Pens.Black, s.StartPoint(conv).X- s.R / 10, s.StartPoint(conv).Y- s.R / 10, s.R/5, s.R / 5);
            g.DrawEllipse(Pens.Black, s.EndPoint(conv).X - s.R / 10, s.EndPoint(conv).Y - s.R / 10, s.R / 5, s.R / 5);

            if(!(s.StartAngle==0&&s.SweepAngle==360))
            g.DrawLine(Pens.Black,s.StartPoint(conv),s.EndPoint(conv));

            g.Dispose();
            return bmp;
       }
    }
}
