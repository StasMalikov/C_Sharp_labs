using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4_test_
{
    public partial class MainForm : Form
    {
        Scene scene;
        Camera camera;
        private MouseEventArgs e0;
        Screen screen;
        bool mouse;
        Func.Func f_model;

        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            scene = new Scene();
            camera = new Camera();
            f_model = new Lab_4_test_.Func.Func(-1, 1, 0, 2, 15, 15);
            scene.models.Add(f_model);
            scene.models.Add(new Axes());
            radioButton1.Tag = new F1();
            radioButton2.Tag = new F2();
            radioButton3.Tag = new F3();
            radioButton4.Tag = new F4();
            radioButton5.Tag = new F5();
            radioButton6.Tag = new F6();
            radioButton7.Tag = new F7();
            radioButton8.Tag = new F8();
        }
      
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (!mouse)
            {
                screen = new Screen(Size, new RectangleF(-5, -5, 10, 10));
                mouse = true;
            }
            Bitmap bmp = scene.DrawAll(screen, camera);
            e.Graphics.DrawImage(bmp,0,0);
            bmp.Dispose();
        }
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            double k;
            if (e.Delta < 0)
                k = 1.23;
            else
                k = 0.77;
            screen = new Screen(Size, new RectangleF(screen.Rectangle.X * (float)k, screen.Rectangle.Y * (float)k,
                screen.Rectangle.Width * (float)k, screen.Rectangle.Height * (float)k));
            Invalidate();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
        Point last = new Point();
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
                last = e.Location;
            if (e.Button.HasFlag(MouseButtons.Right))
                e0 = e;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left) && !last.IsEmpty)
            {
                int dx = e.X - last.X;
                int dy = e.Y - last.Y;
                last = e.Location;
                camera.View = Matrix4.Rotate(2, dx * (float)Math.PI / 180) *
                              Matrix4.Rotate(0, dy * (float)Math.PI / 180) * camera.View;
                Invalidate();
            }
            if (e.Button.HasFlag(MouseButtons.Right))
            {
                float dx = (screen.XX(e.X) - screen.XX(e0.X)) / 100;
                float dy = (screen.YY(e.Y) - screen.YY(e0.Y)) / 100;
                e0 = e;
                screen = new Screen(Size, new RectangleF(screen.Rectangle.X + dx, screen.Rectangle.Y - dy,
                    screen.Rectangle.Height, screen.Rectangle.Width));
                Invalidate();
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
                last = e.Location;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            f_model.function = (sender as RadioButton).Tag as IFunc;
            Invalidate();
        }

        private void StartX_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            f_model.StartX = (float)StartX_numericUpDown.Value;
            Invalidate();
        }

        private void EndX_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            f_model.EndX = (float)EndX_numericUpDown.Value;
            Invalidate();
        }

        private void StartY_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            f_model.StartY = (float)StartY_numericUpDown.Value;
            Invalidate();
        }

        private void EndY_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            f_model.EndY = (float)EndY_numericUpDown.Value;
            Invalidate();
        }

        private void N2_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            f_model.N2 = (float)N2_numericUpDown.Value;
            Invalidate();
        }

        private void N1_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            f_model.N1 = (float)N1_numericUpDown.Value;
            Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MouseWheel += new MouseEventHandler(Form1_MouseWheel);
        }
    }
}
