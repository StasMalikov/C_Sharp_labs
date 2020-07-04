using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    public class Planet
    {
        private string _name;
        public string Name { get { return _name; } }
        private int _weight;
        private int _radius;
        private int _area;
        private double _duratonOfDays;

        public int MainLansNumber
        {
            get {
                return this.MainLands.Count;
            }   
        }

        public List<Ocean> Oceans { get; set; }
        public List<Island> Islands { get; set; }
        public List<MainLand> MainLands { get; set; }

        public Planet(string name)
        {
            _name = name;
            MainLands = new List<MainLand>();
            Oceans = new List<Ocean>();
            Islands = new List<Island>();
        }
    }
}
