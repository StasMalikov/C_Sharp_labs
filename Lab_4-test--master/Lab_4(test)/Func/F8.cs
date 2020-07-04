using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_4_test_
{
   public class F8: IFunc
    {
         public float F(float x, float y)
        {
            return (float)Math.Pow(Math.E, (Math.Sin(x) + Math.Cos(x)) / (x * x + 1));
        }
        public bool FuncTry(float x, float y)
        {

            return true;
        }
    }
}
