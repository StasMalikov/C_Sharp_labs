using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Task_4
{
    public partial class MainForm : Form
    {
        Main main;
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Graphics g = this.CreateGraphics();
            main = new Main(g,ClientRectangle);
            Car.NewCar(main);
            Man.NewMan(main);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ChangeLight_button_Click(object sender, EventArgs e)
        {
            main.ChangeLight(null);
        }
    }
}
