using System;
using System.Drawing;
namespace Task_3_restructered_
{
    public class Segment
    {
        public Vector2 Center { get; set; }
        public float R { get; set; }
        public float StartAngle { get; set; }
        public float SweepAngle { get; set; }

        public Segment(int x, int y, int r, float startangl, float sweepangle)
        {
            Center = new Vector2(x, y);
            R = r;
            StartAngle = startangl;
            SweepAngle = sweepangle;
        }
        public void CalculateRadius(Point pt, ScreenConverter conv)
        {
            R = (float)Math.Sqrt(Math.Pow(pt.X - conv.II(Center.X), 2) + Math.Pow(pt.Y - conv.JJ(Center.Y), 2));
        }
        public void CalculateAngle(Point pt, ScreenConverter conv, bool start)
        {
            double x;
            double y;
            x = pt.X - conv.II(Center.X);
            y = pt.Y - conv.JJ(Center.Y);

            float alpha = (float)(Math.Atan2(y, x) * 180 / Math.PI);

            if (start)
            {
                StartAngle = alpha;
            }
            else
            {
                if (alpha < 0)
                {
                    if (StartAngle > 90 && StartAngle < 180)
                    {
                        SweepAngle = 360 - StartAngle - Math.Abs(alpha);
                    }
                    else
                    {
                        SweepAngle = 360 - StartAngle - Math.Abs(alpha);
                        if (SweepAngle > 360)
                            SweepAngle = SweepAngle % 360;
                    }
                }
                else
                {
                    if (StartAngle > 90 && StartAngle < 180)
                    {
                        SweepAngle = 360 + alpha - StartAngle;
                        SweepAngle = SweepAngle % 360;
                    }
                    else
                    {
                        if (StartAngle < 0)
                            SweepAngle = -StartAngle + alpha;
                        else
                            SweepAngle = alpha;
                    }
                }
            }
        }



        public bool IsEnd(Point pt, ScreenConverter conv)
        {
            int ptLength = (int)Math.Sqrt(Math.Pow(pt.X - EndPoint(conv).X, 2)
                + Math.Pow(pt.Y - EndPoint(conv).Y, 2));
            if (ptLength >= 0 && ptLength <= R / 5)
            {
                return true;
            }

            return false;

        }
        public bool IsStart(Point pt, ScreenConverter conv)
        {
            int ptLength = Math.Abs((int)Math.Sqrt(Math.Pow(pt.X - StartPoint(conv).X, 2)
                + Math.Pow(pt.Y - StartPoint(conv).Y, 2)));
            if (ptLength >= 0 && ptLength <= R / 5)
            {
                return true;
            }

            return false;
        }
        public bool IsInside(Point pt, ScreenConverter conv)
        {
            int ptLength = Math.Abs((int)Math.Sqrt(Math.Pow(pt.X - conv.II(Center.X), 2) + Math.Pow(pt.Y - conv.JJ(Center.Y), 2)));

            if (ptLength >= 0 && ptLength <= R)
            {
                return true;
            }

            return false;

        }
        public Point StartPoint(ScreenConverter s)
        {
            Point p = new Point();
            p.X = (int)(s.II(Center.X) + R * Math.Cos(StartAngle * Math.PI / 180));
            p.Y = (int)(s.JJ(Center.Y) + R * Math.Sin(StartAngle * Math.PI / 180)); ;
            return p;
        }
        public Point EndPoint(ScreenConverter s)
        {
            Point p = new Point();
            p.X = (int)(s.II(Center.X) + R * Math.Cos((SweepAngle + StartAngle) * Math.PI / 180));
            p.Y = (int)(s.JJ(Center.Y) + R * Math.Sin((SweepAngle + StartAngle) * Math.PI / 180));
            return p;
        }
    }
}
