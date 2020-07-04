using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_4_test_
{
   public class F3: IFunc
    {
         public float F(float x, float y)
        {
            return (float)(Math.Pow(x, 1 / 3) * Math.Sin(y));
        }
        public bool FuncTry(float x, float y)
        {

            return true;
        }
    }
}
