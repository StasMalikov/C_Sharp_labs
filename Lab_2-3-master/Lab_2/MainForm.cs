using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            x0_textBox.Text = "600";
            y0_textBox.Text = "200";
            Weight_textBox.Text = "70";
            Height_textBox.Text = "180";
            Brezenham_radioButton.Checked = true;
        }

        private void DrawEllipse_button_Click(object sender, EventArgs e)
        {
            if (Brezenham_radioButton.Checked)
            {
                Brezenham b = new Brezenham(MainPanel.Width, MainPanel.Height);
                MainPanel.CreateGraphics().DrawImage(b.DrawEllipse(Convert.ToInt32(x0_textBox.Text),
                    Convert.ToInt32(y0_textBox.Text), Convert.ToInt32(Weight_textBox.Text) / 2,
                    Convert.ToInt32(Height_textBox.Text) / 2, Color.Black), 0, 0);
            }
            if (Wu_radioButton.Checked)
            {
                Wu w = new Wu(MainPanel.Width, MainPanel.Height);
                MainPanel.CreateGraphics().DrawImage(w.DrawEllipse(Convert.ToInt32(x0_textBox.Text),
                    Convert.ToInt32(y0_textBox.Text), Convert.ToInt32(Weight_textBox.Text) / 2,
                    Convert.ToInt32(Height_textBox.Text) / 2, Color.Red), 0, 0);
            }
        }

        private void DrawArc_button_Click(object sender, EventArgs e)
        {
            if (Brezenham_radioButton.Checked)
            {
                Brezenham_Arc b = new Brezenham_Arc(MainPanel.Width, MainPanel.Height);
                MainPanel.CreateGraphics().DrawImage(b.DrawArc(Convert.ToInt32(x0_textBox.Text),
                    Convert.ToInt32(y0_textBox.Text), Convert.ToInt32(Weight_textBox.Text) / 2,
                    Convert.ToInt32(Height_textBox.Text) / 2, Convert.ToInt32(StartAngle_textBox.Text),
                    Convert.ToInt32(EndAngle_textBox.Text),Color.Black), 0, 0);
            }
            if (Wu_radioButton.Checked)
            {
                Wu_Arc b = new Wu_Arc(MainPanel.Width, MainPanel.Height);
                MainPanel.CreateGraphics().DrawImage(b.DrawArc(Convert.ToInt32(x0_textBox.Text),
                    Convert.ToInt32(y0_textBox.Text), Convert.ToInt32(Weight_textBox.Text) / 2,
                    Convert.ToInt32(Height_textBox.Text) / 2, Convert.ToInt32(StartAngle_textBox.Text),
                    Convert.ToInt32(EndAngle_textBox.Text), Color.Black), 0, 0);
            }
        }

        private void DrawPie_button_Click(object sender, EventArgs e)
        {
            if (Brezenham_radioButton.Checked)
            {
                Brezenham_Pie b = new Brezenham_Pie(MainPanel.Width, MainPanel.Height);
                MainPanel.CreateGraphics().DrawImage(b.DrawPie(Convert.ToInt32(x0_textBox.Text),
                    Convert.ToInt32(y0_textBox.Text), Convert.ToInt32(Weight_textBox.Text) / 2,
                    Convert.ToInt32(Height_textBox.Text) / 2, Convert.ToInt32(StartAngle_textBox.Text),
                    Convert.ToInt32(EndAngle_textBox.Text), Color.Black), 0, 0);
            }
            if (Wu_radioButton.Checked)
            {
                Wu_Pie b = new Wu_Pie(MainPanel.Width, MainPanel.Height);
                MainPanel.CreateGraphics().DrawImage(b.DrawPie(Convert.ToInt32(x0_textBox.Text),
                    Convert.ToInt32(y0_textBox.Text), Convert.ToInt32(Weight_textBox.Text) / 2,
                    Convert.ToInt32(Height_textBox.Text) / 2, Convert.ToInt32(StartAngle_textBox.Text),
                    Convert.ToInt32(EndAngle_textBox.Text), Color.Black), 0, 0);
            }
        }

        private void Сircle_button_Click(object sender, EventArgs e)
        {
            DrawForm d = new DrawForm();
            d.Show();
        }
    }
}
