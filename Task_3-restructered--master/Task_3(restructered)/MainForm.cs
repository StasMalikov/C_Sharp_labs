using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task_3_restructered_
{
    public partial class MainForm : Form
    {
        private MouseEventArgs e0;
        public ScreenConverter converter;
        public Axes _Axes;
        public Segment _Segment;
        public bool drawing = false;
        public bool inside = false;
        public bool start = false;
        public bool end = false;
        public MainForm()
        {
            InitializeComponent();
            converter = new ScreenConverter(ClientRectangle);
            _Axes = new Axes(converter);
            _Segment = new Segment(100, 100, 50,
                0, 90);
            Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            bmp = _Axes.DrawAxes(bmp);
            bmp = Drawer.Draw(bmp, _Segment, converter);
            e.Graphics.DrawImage(bmp, 0, 0);
            bmp.Dispose();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            inside = _Segment.IsInside(new Point(e.Location.X, e.Location.Y), converter);
            start = _Segment.IsStart(new Point(e.Location.X, e.Location.Y), converter);
            end = _Segment.IsEnd(new Point(e.Location.X, e.Location.Y), converter);
            e0 = e;
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
            start = false;
            end = false;
            inside = false;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (start)
            {

                _Segment.CalculateAngle(e.Location, converter, true);
                _Segment.CalculateRadius(e.Location, converter);
                Invalidate();
            }
            else
            if (end)
            {
                _Segment.CalculateAngle(e.Location, converter, false);
                _Segment.CalculateRadius(e.Location, converter);
                Invalidate();
            }
            else
          if (inside)
            {
                
                double dx = converter.XX(e.X) - converter.XX(e0.X);
                double dy = converter.YY(e.Y) - converter.YY(e0.Y);
                e0 = e;
                _Segment.Center.X += (float)dx;
                _Segment.Center.Y += (float)dy;
                Invalidate();
            }
            else
          if (drawing)
            {
                double dx = converter.XX(e.X) - converter.XX(e0.X);
                double dy = converter.YY(e.Y) - converter.YY(e0.Y);
                e0 = e;
                converter.x1 -= dx; converter.y1 -= dy;
                converter.x2 -= dx; converter.y2 -= dy;
                Invalidate();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MouseWheel += new MouseEventHandler(Form1_MouseWheel);
        }
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            double coeff;
            double x = converter.XX(e.X);
            double y = converter.YY(e.Y);
            if (e.Delta < 0)
            {
                coeff = 1.03;
                _Segment.R -= 1;
            }
            else
            {
                coeff = 0.97;
                _Segment.R += 1;
            }
            converter.x1 = x - (x - converter.x1) * coeff;
            converter.x2 = x + (converter.x2 - x) * coeff;
            converter.y1 = y - (y - converter.y1) * coeff;
            converter.y2 = y + (converter.y2 - y) * coeff;
            Invalidate();
        }
    }
}
