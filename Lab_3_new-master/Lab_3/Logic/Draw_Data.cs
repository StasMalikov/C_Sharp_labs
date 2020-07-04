using System.Drawing;
using System;
using System.Windows.Forms;

namespace Lab_3.Logic
{
    public class Draw_Data
    {
        public Draw_Data()
        {
        }
        public Draw_Data(int x, int y, int a, int b, double startAngle, double endAngle,int h,int w)
        {
            Hr = h;
            Wr = w;
            A = a;
            B = a;
            EndAngle = endAngle;
            StartAngle = startAngle;
            StartX = x;
            StartY = y;
            endPoint = new Point(Math.Abs((int)(A * Math.Cos(EndAngle))) + StartX,
                                        Math.Abs((int)(B * Math.Sin(EndAngle))) + StartY);

            startPoint = new Point(Math.Abs((int)(A * Math.Cos(StartAngle))) + StartX,
                                          Math.Abs((int)(B * Math.Sin(StartAngle))) + StartY);
        }

        public double GetStart(MouseEventArgs e)
        {
            return Math.Sqrt((e.X - startPoint.X) * (e.X - startPoint.X) +
                (e.Y - startPoint.Y) * (e.Y - startPoint.Y));
        }
        public double GetEnd(MouseEventArgs e)
        {
            return Math.Sqrt((e.X - endPoint.X) * (e.X - endPoint.X)
                + (e.Y - endPoint.Y) * (e.Y - endPoint.Y));
        }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int Xr{ get; set; }
        public int Yr { get; set; }
        public int Hr { get; set; }
        public int Wr { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public double StartAngle { get; set; }
        public double EndAngle { get; set; }
        public bool drawing { get; set; }
        public int delta { get; set; }
        public int dx { get; set; }
        public int dy { get; set; }
        public Point endPoint;
        public Point startPoint;
        public int _Radious { get; set; }
        public int radius = 10;
        public int deltaEnd { get; set; }
        public int deltaStart { get; set; }
        public bool endBool { get; set; }
        public bool startBool { get; set; }
    }
}
