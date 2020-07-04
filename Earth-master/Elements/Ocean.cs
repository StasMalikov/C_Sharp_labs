using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    public class Ocean
    {
        private string _name;
        public string Name { get { return _name; } }
        private int _area;
        private int _averageDepth;

        public Ocean(string name,int area,int deph)
        {
            _name = name;
            _area = area;
            _averageDepth = deph;
        }  
    }
}
