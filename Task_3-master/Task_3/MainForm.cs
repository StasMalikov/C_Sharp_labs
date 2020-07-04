using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Task_3
{
    public partial class MainForm : Form
    {
        public List<IMusicInstrument> instruments = new List<IMusicInstrument>();

        public MainForm()
        {
            InitializeComponent();

            IMusicInstrument a = new ElectronicGuitar("Гитара №1", 5, 0.7, 500);
            IMusicInstrument b = new ElectronicGuitar("Гитара №2", 4, 0.9, 800);
            IMusicInstrument c = new ElectronicGuitar("Гитара №3", 3, 0.6, 400);
            instruments.Add(a);
            instruments.Add(b);
            instruments.Add(c);
        }


        private void GetInfoFromList_button_Click(object sender, EventArgs e)
        {
            foreach (ElectronicGuitar tmp in instruments)
            {
                textBox.Text += tmp.GetInfo();
            }
        }

        private void Compare_button_Click(object sender, EventArgs e)
        {
            instruments[0].Reconfigure(2, 0.1);
        }
    }
}
