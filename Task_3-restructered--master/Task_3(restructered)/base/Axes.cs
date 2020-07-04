using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_3_restructered_
{
   public class Axes
    {
        ScreenConverter conv;
        Graphics g;
        Font aFont;
        Pen MyPen1 = new Pen(Brushes.Black, 1);
        Pen MyPen2 = new Pen(Brushes.Black, 1);
        public Axes(ScreenConverter c)
        {
            conv = c;
            aFont = new Font("Arial", 7, FontStyle.Bold);
        }
        public Bitmap DrawAxes(Bitmap bitmap)
        {
            g = Graphics.FromImage(bitmap);
            OX();
            OY();
            return bitmap;
        }
        
        void OX()//ось х
        {
            g.DrawLine(Pens.LightBlue, conv.II(conv.x1), conv.JJ(0), conv.II(conv.x2), conv.JJ(0));
            double h1 = HH(conv.x1, conv.x2);
            int k1 = (int)Math.Round(conv.x1 / h1) - 1;
            int k2 = (int)Math.Round(conv.x2 / h1);
            byte Digits = GetDigits(Math.Abs(conv.x2 - conv.x1));
            for (int i = k1; i <= k2; i++)
            {
                g.DrawLine(MyPen2, conv.II(i * h1), conv.JJ(0) - 7, conv.II(i * h1), conv.JJ(0) + 7);
                for (int j = 1; j <= 9; j++)
                    g.DrawLine(MyPen2, conv.II(i * h1 + j * h1 / 10), conv.JJ(0) - 3, conv.II(i * h1 + j * h1 / 10), conv.JJ(0) + 3);
                string s = Convert.ToString(Math.Round(h1 * i, Digits));
                g.DrawString(s, aFont, Brushes.Black, conv.II(i * h1) - 5, conv.JJ(0) - 13);
            }
        }

        void OY()//ось у
        {
            g.DrawLine(Pens.LightBlue, conv.II(0), conv.JJ(conv.y1), conv.II(0), conv.JJ(conv.y2));
            double h1 = HH(conv.y1, conv.y2); int k1 = (int)Math.Round(conv.y1 / h1) - 1;
            int k2 = (int)Math.Round(conv.y2 / h1);
            int Digits = GetDigits(Math.Abs(conv.y2 - conv.y1));
            for (int i = k1; i <= k2; i++)
            {
                g.DrawLine(MyPen2, conv.II(0) - 7, conv.JJ(i * h1), conv.II(0) + 7, conv.JJ(i * h1));
                for (int j = 1; j <= 9; j++)
                    g.DrawLine(MyPen2, conv.II(0) - 3, conv.JJ(i * h1 + j * h1 / 10), conv.II(0) + 3, conv.JJ(i * h1 + j * h1 / 10));
                string s = Convert.ToString(Math.Round(h1 * i, Digits));
                g.DrawString(s, aFont, Brushes.Black, conv.II(0) + 5, conv.JJ(i * h1) - 5);
            }
        }

        double HH(double a1, double a2)
        {
            double Result = 1;
            while (Math.Abs(a2 - a1) / Result < 1)
                Result /= 10.0;
            while (Math.Abs(a2 - a1) / Result >= 10)
                Result *= 10.0;
            if (Math.Abs(a2 - a1) / Result < 2.0)
                Result /= 5.0;
            if (Math.Abs(a2 - a1) / Result < 5.0)
                Result /= 2.0;
            return Result;
        }

        byte GetDigits(double dx)
        {
            byte Result;
            if (dx >= 5) Result = 0;
            else
                if (dx >= 0.5) Result = 1;
            else
                    if (dx >= 0.05) Result = 2;
            else
                        if (dx >= 0.005) Result = 3;
            else
                            if (dx >= 0.0005) Result = 4; else Result = 5;
            return Result;
        }
    }
}
