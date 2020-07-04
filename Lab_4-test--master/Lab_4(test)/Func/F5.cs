using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_4_test_
{
   public class F5: IFunc
    {
        public float F(float x, float y)
        {
            return (float)((1 / (x * x * x + 2)) + Math.Log(y));
        }
        public bool FuncTry(float x, float y)
        {
            if (x * x * x + 2 == 0)
                return false;
            if (y <= 0)
                return false;
            return true;
        }
    }
}
