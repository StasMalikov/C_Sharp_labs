using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_6__Bresenham_Visualisation_
{
   public class Algoritm
    {
        public static void BresenhamLine(Graphics g, int x, int y, int x2, int y2, Color color, int he, int we)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;

            if (w < 0)
                dx1 = -1;
            else if (w > 0)
                dx1 = 1;

            if (h < 0)
                dy1 = -1;
            else if (h > 0)
                dy1 = 1;

            if (w < 0)
                dx2 = -1;
            else if (w > 0)
                dx2 = 1;

            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0)
                    dy2 = -1;
                else if (h > 0)
                    dy2 = 1;

                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                if ((x >= 0) && (y >= 0) && (x < we) && (y < he))
                {
                    g.FillRectangle(new SolidBrush(color), x, y, 1, 1);
                }
                // bitmap.SetPixel(x, y, color);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }
    }
}
