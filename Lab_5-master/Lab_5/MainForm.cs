using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lab_5
{
    public partial class MainForm : Form
    {
        Graphics g;
        Drawer drawer;
        Locomotive locomotive;
        TimerCallback _timeback;
        System.Threading.Timer _timer;
        public MainForm()
        {
            InitializeComponent();
           
            g = this.CreateGraphics();
            locomotive = new Locomotive(0, (float)FrictionForce_numericUpDown.Value, (float)FrictionForce_numericUpDown.Value);
            drawer = new Drawer(g,ClientRectangle);
            _timeback = new TimerCallback(Tick);
            _timer = new System.Threading.Timer(_timeback, null, 0, 10);
        }

        public void Tick(object state)
        {
            locomotive.Update();
            drawer.DrawPic(locomotive);//.Clone());
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            drawer.DrawPic(locomotive);//.Clone());
        }
        

        private void AddToEnd_button_Click(object sender, EventArgs e)
        {
            if (locomotive.Wheels.Count > 0)
            {
                locomotive.Wheels.Add(new Wheel(100,
                    locomotive.Wheels[locomotive.Wheels.Count - 1].Center.X - 120,
                    locomotive.Wheels[locomotive.Wheels.Count - 1].Center.Y,
                    false));
            }
            else
            {
                locomotive.Wheels.Add(new Wheel(100, 120, 200, true));
            }
        }

        private void ExternalForce_numericUpDown_ValueChanged(object sender, EventArgs e)
        {

            locomotive.L_Forces.External_force = (float)ExternalForce_numericUpDown.Value;
        }

        private void FrictionForce_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            locomotive.L_Forces.Friction_force = (float)FrictionForce_numericUpDown.Value;
        }

        private void Up_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < locomotive.Wheels.Count; i++)
            {
                locomotive.Wheels[i].Center = locomotive.Wheels[i].Center+new Vector2(0,-10);
            }
        }

        private void Left_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < locomotive.Wheels.Count; i++)
            {
                locomotive.Wheels[i].Center = locomotive.Wheels[i].Center + new Vector2(-10, 0);
            }
        }

        private void Right_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < locomotive.Wheels.Count; i++)
            {
                locomotive.Wheels[i].Center = locomotive.Wheels[i].Center + new Vector2(10, 0);
            }
        }

        private void Down_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < locomotive.Wheels.Count; i++)
            {
                locomotive.Wheels[i].Center = locomotive.Wheels[i].Center + new Vector2(0, 10);
            }
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            if (locomotive.Wheels.Count > 0)
            {
                if (locomotive.Wheels[locomotive.Wheels.Count - 1].Special)
                {
                    if(locomotive.Wheels.Count > 1)
                    locomotive.Wheels[locomotive.Wheels.Count - 2].Special = true;
                }
                locomotive.Wheels.RemoveAt(locomotive.Wheels.Count - 1);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
