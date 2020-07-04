using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_6__Bresenham_Visualisation_
{
    public partial class MainForm : Form
    {
        public Drawer dr;
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            dr = new Drawer(this.CreateGraphics(), ClientRectangle);
            dr.DrawAllPicture();
        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
        }

        private void draw_button_Click(object sender, EventArgs e)
        {
            dr.p1.X = Convert.ToInt32(x1_textBox.Text);
            dr.p1.Y = Convert.ToInt32(y1_textBox.Text);
            dr.p2.X = Convert.ToInt32(x2_textBox.Text);
            dr.p2.Y = Convert.ToInt32(y2_textBox.Text);
            dr.DrawAllPicture();
        }
    }
}
