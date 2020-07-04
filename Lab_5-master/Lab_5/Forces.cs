using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
   public class Forces
    {
        public float External_force { get; set; } // внешняя сила
        public float Friction_force { get; set; } // сила трения

        public Forces(float external, float friction)
        {
            External_force = external;
            Friction_force = friction;
        }
    }
}
