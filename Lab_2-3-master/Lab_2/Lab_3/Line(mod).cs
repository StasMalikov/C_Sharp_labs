using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_3
{
    public class Line
    {
        public static void Newline(Graphics g, int x, int y, int x2, int y2, Color color)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                g.FillRectangle( new SolidBrush(color), x, y, 1, 1);
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

        public static Bitmap Wuline(Bitmap bitmap, int x1, int y1, int x2, int y2,Color c)
        {
            Graphics g = Graphics.FromImage(bitmap);
            int x = x1;
            int y = y1;
            int Dx = x2 - x1;
            int Dy = y2 - y1;
            int e = 2 * Dy - Dx;
            float d;
            SolidBrush b1, b2;
            for (int i = 1; i <= Dx; i++)
            {
                d = -1F * e / (Dy + Dx) / 1.15F;
                if (e >= 0)
                {
                    b1 = new SolidBrush(SetColor(1F / 2 - d));
                    b2 = new SolidBrush(SetColor(1F / 2 + d));
                    g.FillRectangle(b1, x, y, 1, 1);
                    g.FillRectangle(b2, x, y + 1, 1, 1);
                    y++;
                    e += -2 * Dx + 2 * Dy;
                }
                else
                {
                    b1 = new SolidBrush(SetColor(1F / 2 + d));
                    b2 = new SolidBrush(SetColor(1F / 2 - d));
                    g.FillRectangle(b2, x, y, 1, 1);
                    g.FillRectangle(b1, x, y - 1, 1, 1);
                    e += 2 * Dy;
                }
                x++;
                b1.Dispose();
                b2.Dispose();
            }
            return bitmap;
        }

        public static Bitmap Wu(Bitmap bitmap, int x, int y, int x2, int y2, Color color)
        {
            int _x = x;
            int _y = y;
            SolidBrush b1, b2;
            Graphics g = Graphics.FromImage(bitmap);
            int w = x2 - _x;
            int h = y2 - _y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                //bitmap.SetPixel(x, y, color);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    int Dx = _x - x;
                    int Dy = _y - y;
                    int e = 2 * Dy - Dx;
                    float d = -1F * e / (Dy + Dx) / 1.15F;
                    if (!((Dx == 0) && (Dy == 0)))
                    {
                        b1 = new SolidBrush(SetColor(Math.Abs(1F / 2 + d)));//насыщенный
                        b2 = new SolidBrush(SetColor(Math.Abs(1F / 2 - d)));//слабый

                        g.FillRectangle(b2, _x, _y, 1, 1);
                        g.FillRectangle(b1, _x, _y + 1, 1, 1);
                    }
                    numerator -= longest;

                    _x += dx1;
                    _y += dy1;
                }
                else
                {
                    int Dx = _x - x;
                    int Dy = _y - y;
                    int e = 2 * Dy - Dx;
                    float d = -1F * e / (Dy + Dx) / 1.15F;
                    if (!((Dx == 0) && (Dy == 0)))
                    {
                        b1 = new SolidBrush(SetColor(Math.Abs(1F / 2 - d)));//насыщенный
                        b2 = new SolidBrush(SetColor(Math.Abs(1F / 2 + d)));//слабый
                        g.FillRectangle(b2, _x, _y, 1, 1);
                        g.FillRectangle(b1, _x, _y - 1, 1, 1);
                    }
                    _x += dx2;
                    _y += dy2;   
                }
            }
            return bitmap;
        }

        private static Color SetColor(float t)
        {
            int c;
            if (t == float.NaN)
                c = 0;
            else
            {
                 c = Convert.ToInt32(255 * t);
            }
            if (c > 255)
                c = 255;
            Color res = Color.FromArgb(c, c, c);
            return res;
        }
    }
}
