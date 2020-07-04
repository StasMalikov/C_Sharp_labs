//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Lab_2
//{
//    public partial class DrawForm : Form
//    {
//        double coeff = 1;
//        Graphics g;

//        //MyClass G = new MyClass();
//        public int A;
//        public int B;
//        public double StartAngle;
//        public double EndAngle;
//        bool drawing = false;

//        MouseEventArgs e0;
//        public DrawForm(int a, int b, double startAngle,double endAngle)
//        {
//            A = a;
//            B = b;
//            StartAngle = startAngle;
//            EndAngle = endAngle;
//           // draw
//        }

//        public DrawForm()
//        {
//            InitializeComponent();
//            g = this.CreateGraphics();
//        }
//        public void MyDraw(Graphics g)
//        {
//           /// G.Draw(g, ClientRectangle, flFunc);
//        }

//        private void DrawForm_MouseDown(object sender, MouseEventArgs e)
//        {
//            drawing = true;
//            e0 = e;
//        }

//        private void DrawForm_MouseMove(object sender, MouseEventArgs e)
//        {
//            if (drawing)
//            //{
//            //    double dx = G.XX(e.X) - G.XX(e0.X);
//            //    double dy = G.YY(e.Y) - G.YY(e0.Y);
//            //    e0 = e;
//            //    G.x1 -= dx; G.y1 -= dy;
//            //    G.x2 -= dx; G.y2 -= dy;
//            //    MyDraw(g);
//            }
//        }

//        private void DrawForm_MouseUp(object sender, MouseEventArgs e)
//        {
//            drawing = false;
//        }

//        private void DrawForm_Paint(object sender, PaintEventArgs e)
//        {
//            MyDraw(g);
//        }

//        private void DrawForm_Resize(object sender, EventArgs e)
//        {
//            MyDraw(g);
//        }

//        private void DrawForm_Load(object sender, EventArgs e)
//        {
//            MouseWheel += new MouseEventHandler(Form1_MouseWheel);
//        }
//        void Form1_MouseWheel(object sender, MouseEventArgs e)
//        {
//            //double x = G.XX(e.X);
//            //double y = G.YY(e.Y);
//            //if (e.Delta < 0)
//            //    coeff = 1.03;
//            //else
//            //    coeff = 0.97;
//            //G.x1 = x - (x - G.x1) * coeff;
//            //G.x2 = x + (G.x2 - x) * coeff;
//            //G.y1 = y - (y - G.y1) * coeff;
//            //G.y2 = y + (G.y2 - y) * coeff;
//            //MyDraw(g);
//        }
//    }
//}
