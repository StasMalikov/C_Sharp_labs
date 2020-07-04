using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elements;

namespace Earth
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
             
            string text = "";
            Planet Earth = new Planet("Земля");
            text += Earth.Name;
            text += Environment.NewLine;

            Earth.MainLands.Add(new MainLand("Евразия", 54));
            Earth.MainLands.Add(new MainLand("Африка", 29));
            Earth.MainLands.Add(new MainLand("Северная Америка", 20));
            Earth.MainLands.Add(new MainLand("Южная Америка", 18));
            Earth.MainLands.Add(new MainLand("Австралия", 7));
            Earth.MainLands.Add(new MainLand("Антарктида", 12));


            foreach (var land in Earth.MainLands) {
                text += land.Name;
                text += " ";
            }

            //Earth.MainLands.ForEach(land => {
            //    text += land.GetName();
            //    text += " ";
            //});

            text += Environment.NewLine;
            text += "Число материков: ";
            text += Earth.MainLansNumber;
            Main_textBox.Text = text;

        }
    }
}
