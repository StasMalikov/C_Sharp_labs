using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab_3;
using Lab_3.Logic;
namespace Lab_2
{
    public partial class DrawFormScreen : Form
    {
        private MouseEventArgs e0;
        Draw_Data _data;
        Brezenham_Pie_mod p;
        Converter conv;
        public DrawFormScreen()
        {
            InitializeComponent();
        }
        public DrawFormScreen(int x, int y, int a, int b, double startAngle, double endAngle)
        {
            _data = new Draw_Data(x, y, a, a, startAngle, endAngle, ClientRectangle.Height, ClientRectangle.Width);
            InitializeComponent();
            conv = new Converter( ClientRectangle.Height, ClientRectangle.Width,_data);
            p = new Brezenham_Pie_mod();

            MyDraw();
        }
        public void MyDraw()
        {
           Graphics g = this.CreateGraphics();
            conv.Refresh(_data, ClientRectangle.Height, ClientRectangle.Width);
            g.DrawImage(p.DrawPie(conv.II, conv.JJ,
                 _data.A * ClientRectangle.Width / _data.Wr+_data._Radious,
                 _data.B * ClientRectangle.Height / _data.Hr+ _data._Radious,
                    (int)_data.StartAngle + _data.deltaStart, 
                    (int)_data.EndAngle + _data.deltaEnd,
                        out _data.startPoint, out _data.endPoint, Color.Black,
                        ClientRectangle.Height,ClientRectangle.Width), 0, 0);
        }


        private void DrawFormScreen_Load(object sender, EventArgs e)
        {
            MouseWheel += new MouseEventHandler(Form1_MouseWheel);
        }
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                _data.Hr += 5;
                _data.Wr += 5;
            }
            else
            {
                _data.Hr -= 5;
                _data.Wr -= 5;
            }
            MyDraw();
        }
        private void DrawFormScreen_MouseDown(object sender, MouseEventArgs e)
        {
            double end = _data.GetEnd(e);
            double start = _data.GetStart(e);

            if (_data.radius >= end)
            {
                _data.endBool = true;
                e0 = e;
            }
            else if (_data.radius >= start)
            {
                _data.startBool = true;
                e0 = e;
            }
            else
            {
                _data.drawing = true;
                e0 = e;
            }
        }

        private void DrawFormScreen_MouseUp(object sender, MouseEventArgs e)
        {
            _data.drawing = false;
            _data.startBool = false;
            _data.endBool = false;
        }

        private void DrawFormScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (_data.startBool)
            {
                _data.deltaStart += e.X - e0.X;
                _data._Radious += e.X - e0.X;
                e0 = e;               
                MyDraw();
            }
            else if (_data.endBool)
            {
                _data.deltaEnd += e.X - e0.X;
                _data._Radious += e.X - e0.X;
                e0 = e;
                MyDraw();
            }
            else if (_data.drawing)
            {
                _data.dx += e.X - e0.X;
                _data.dy += e.Y - e0.Y;
                e0 = e;
                MyDraw();
            }
        }

        private void DrawFormScreen_Paint(object sender, PaintEventArgs e)
        {
            MyDraw();
        }
    }
}
