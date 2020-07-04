using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Lab_6__Bresenham_Visualisation_
{
   public class Drawer
    {
        public Graphics G;
        public Rectangle size;
        public ScreenConverter sc;
        public Point p1;
        public Point p2;
        int widthSplit;
        int heightSplit;
        public Drawer(Graphics g, Rectangle s)
        {
            G = g;
            size = s;
            sc = new ScreenConverter(s);
            p1 = new Point(-5,-5);
            p2 = new Point(10, 10);
        }

        public void DrawAllPicture()
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            bmp = DrawGrid(bmp, 40);//рисуем сетку
            bmp= DrawAxes(bmp); //рисуем оси
            bmp= DrawL(bmp); // рисуем линию
            bmp = BresenhamLine(bmp, sc.II(p1.X), sc.JJ(p1.Y + 0), sc.II(p2.X), sc.JJ(p2.Y + 0), Color.Gray,
                widthSplit, heightSplit);

            G.DrawImage(bmp, 0, 0);
            bmp.Dispose();
        }

        public Bitmap DrawL(Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(Pens.Black, sc.II(p1.X), sc.JJ(p1.Y), sc.II(p2.X), sc.JJ(p2.Y));
            return bmp;
        }
        public Bitmap DrawAxes(Bitmap bmp)
        {
            Axes axex = new Axes(sc);
            bmp = axex.DrawAxes(bmp);
                return bmp;
        }

        public Bitmap DrawGrid(Bitmap bmp, int splitNumber)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
             widthSplit = bmp.Width / splitNumber;
             heightSplit=bmp.Height/(splitNumber/2);

            Pen pen = new Pen(Color.LightGray,2);

            for (int i = 0; i < bmp.Width; i+=widthSplit)
            {
                g.DrawLine(pen,i,0, i,bmp.Height);
            }

            for (int i = 0; i < bmp.Height; i += heightSplit)
            {
                g.DrawLine(pen, 0, i , bmp.Width, i );
            }

            g.Dispose();
            return bmp;
        }

        public Bitmap BresenhamLine(Bitmap bmp, int x, int y, int x2, int y2, Color color,int DX,int DY)
        {
            bool t=false;
            bool r = false;
            Graphics g = Graphics.FromImage(bmp);
            if (y < y2)
                t = true;

            if (x < x2)
                r = true;

            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;

            if (w < 0)
                dx1 = -DX;
            else if (w > 0)
                dx1 = DX;

            if (h < 0)
                dy1 = -DY;
            else if (h > 0)
                dy1 = DY;

            if (w < 0)
                dx2 = -DX;
            else if (w > 0)
                dx2 = DX;
            int increment = DX;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                increment = DY;
                if (h < 0)
                    dy2 = -DY;
                else if (h > 0)
                    dy2 = DY;

                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i < longest; i+=increment)
            {
                if ((x >= 0) && (y >= 0) && (x < bmp.Width) && (y < bmp.Height))
                {
                    if (t)
                    {
                        if(r)
                        g.FillRectangle(new SolidBrush(color), x, y, DX, DY);
                        else
                            g.FillRectangle(new SolidBrush(color), x-DX, y, DX, DY);
                    }
                    else
                    {
                        if(r)
                        g.FillRectangle(new SolidBrush(color), x, y - DY, DX, DY);
                        else
                            g.FillRectangle(new SolidBrush(color), x-DX, y - DY, DX, DY);
                    }
                    bmp = DrawL(bmp); // рисуем линию
                    G.DrawImage(bmp, 0, 0);
                    Thread.Sleep(1000);
                }
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
            g.Dispose();
            return bmp;
        }
    }
}
