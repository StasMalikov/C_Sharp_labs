using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic_2;

namespace Task_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }



        private void Student_button_Click(object sender, EventArgs e)
        {
            Student s1 = new Student("Иванов", 3.5, 2);
            Main_textBox.Text += s1.StudentInfo();
            Main_textBox.Text += Environment.NewLine;
            Main_textBox.Text += Environment.NewLine;
        }

        private void EnglishStudent_button_Click(object sender, EventArgs e)
        {
            EnglishStudent s2 = new EnglishStudent("Петров", 4.3, 1, true);
            Main_textBox.Text += s2.StudentInfo();
            Main_textBox.Text += Environment.NewLine;
            Main_textBox.Text += Environment.NewLine;
        }

        private void FalseEnglishStud_button_Click(object sender, EventArgs e)
        {
            EnglishStudent s3 = new EnglishStudent("Сидоров", 4.3, 1, false);
            Main_textBox.Text += s3.StudentInfo();
            Main_textBox.Text += Environment.NewLine;
            Main_textBox.Text += Environment.NewLine;
        }
    }
}
