using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_work_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        Point cur = new Point(0, 0);
        public void DrawPicture(Bitmap bitmap)
        {
            //вызывает методы, которые я реализую в рамках лабораторной работы
            //DrawLogic.DrawHorizontalLine(bitmap,Color.Black,10,20,30);
           // DrawLogic.DrawVerticalLine(bitmap, Color.Black, 100, 100, 50);
            DrawLogic.DrawTransverseLine(bitmap, Color.Black, bitmap.Width/2, bitmap.Height / 2, cur.X, cur.Y);

        }

        public void Draw(Graphics g,Rectangle r)
        {
            Bitmap bitmap = new Bitmap(r.Width, r.Height);
            DrawPicture(bitmap);
            g.DrawImage(bitmap, r);
            bitmap.Dispose();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics, e.ClipRectangle);
        }


        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            cur = e.Location; 
            Invalidate();
        }
    }
}
