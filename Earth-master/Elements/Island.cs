using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
   public class Island
    {
        private string _name;
        public string Name { get { return _name; } }

        private int _coastLine;
        private int _area;

        private int[,] _extremePoints;


        public Island(string name, int area)
        {
            _name = name;
            _area = area;           
        }

        public void SetCoordinates(int[,] coordinates)
        {
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                for (int j = 0; j < coordinates.GetLength(1); j++)
                {
                    _extremePoints[i, j] = coordinates[i, j];
                }
            }
        }
    }
}
