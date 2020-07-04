using System;
using System.Windows.Forms;

namespace Discrete_Math
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SetArr_button_Click(object sender, EventArgs e)
        {
            Arr_textBox.Lines = Algorithms.RandomArr(Convert.ToInt32(CountOfArr_textBox.Text));
        }

        private void SequentialSearch_button_Click(object sender, EventArgs e)
        {
            int result=Algorithms.SequentialSearch(
                (Algorithms.TOINT(Arr_textBox.Lines)),Convert.ToInt32(FindNumber_textBox.Text));
            if (result != 0)
            {
                Result_textBox.Text = "Число обходов: ";
                Result_textBox.Text += result.ToString();
            }
            else
            {
                Result_textBox.Text = "Искомое число не найдено.";
            }
        }

        private void BinarySearch_button_Click(object sender, EventArgs e)
        {
            int result = Algorithms.BinarySearch(
                (Algorithms.TOINT(Arr_textBox.Lines)), Convert.ToInt32(FindNumber_textBox.Text));
            if (result != 0)
            {
                Result_textBox.Text = "Число обходов: ";
                Result_textBox.Text += result.ToString();
            }
            else
            {
                Result_textBox.Text = "Искомое число не найдено.";
            }
        }

        private void SortArr_button_Click(object sender, EventArgs e)
        {
            Arr_textBox.Lines = Algorithms.SortArr(Convert.ToInt32(CountOfArr_textBox.Text));
        }

        private void InsertionSort_button_Click(object sender, EventArgs e)
        {
            int c = 0;
            SortArr_textBox.Lines = Algorithms.ToString(Sort.InsertionSort(Algorithms.TOINT(Arr_textBox.Lines),out c));
            Result_textBox.Text = "Число обходов: ";
            Result_textBox.Text += c.ToString();

        }

        private void BinaryInsertionSort_button_Click(object sender, EventArgs e)
        {
            int c = 0;
            SortArr_textBox.Lines = Algorithms.ToString(Sort.BinaryInsertionSort(Algorithms.TOINT(Arr_textBox.Lines), out c));
            Result_textBox.Text = "Число обходов: ";
            Result_textBox.Text += c.ToString();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Bubble_button_Click(object sender, EventArgs e)
        {
            int c = 0;
            int swap = 0;
            SortArr_textBox.Lines = Algorithms.ToString
                (Sort.SortBubl(Algorithms.TOINT(Arr_textBox.Lines),out c,out swap));
            Result_textBox.Text = "Число обходов: ";
            Result_textBox.Text += c.ToString();
            Result_textBox.Text += " Число swap: ";
            Result_textBox.Text += swap.ToString();
        }

        private void Shell_button_Click(object sender, EventArgs e)
        {
            int c = 0;
            int swap = 0;
            SortArr_textBox.Lines = Algorithms.ToString
                (Sort.ShellSort(Algorithms.TOINT(Arr_textBox.Lines), Convert.ToInt32(Step_textBox.Text), out c,out swap));
            Result_textBox.Text = "Число обходов: ";
            Result_textBox.Text += c.ToString();
            Result_textBox.Text += " Число swap: ";
            Result_textBox.Text += swap.ToString();
        }

        private void BackSort_button_Click(object sender, EventArgs e)
        {
            Arr_textBox.Lines = Algorithms.BackSortArr(Convert.ToInt32(CountOfArr_textBox.Text));
        }
    }
}
