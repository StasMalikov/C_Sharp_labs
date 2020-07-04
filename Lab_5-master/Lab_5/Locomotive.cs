using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
   public class Locomotive
    {
        public Forces L_Forces { get; set; }
        public  List<Wheel> Wheels { get; set; }
        public float Speed { get; set; }
        public float StartAngle { get; set; }
        public Locomotive(float speed, float friction, float external)
        {
            Wheels = new List<Wheel>();
            Wheels.Add(new Wheel(100, 360, 200, false));
            Wheels.Add(new Wheel(100, 240, 200, true));
            Wheels.Add(new Wheel(100, 120, 200, false));
            L_Forces = new Forces(external,friction);
            Speed = speed;
            StartAngle = 0;
        }

        public void Update()
        {
            Speed += L_Forces.External_force;
            if (Speed > L_Forces.Friction_force)
                Speed -= L_Forces.Friction_force;
            else Speed = 0;

            StartAngle += Speed;
        }
        public Locomotive Clone()
        {
            Locomotive lcmt = new Locomotive(Speed,L_Forces.Friction_force,L_Forces.External_force);
            lcmt.Wheels = Wheels;
            lcmt.StartAngle = StartAngle;
            return lcmt;
        }
    }

}
