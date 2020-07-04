using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_4_test_
{
   public class F7: IFunc
    {
        public float F(float x, float y)
        {
            return x * x * x * x + y * y * y * y * (x * x + y * y);
        }
        public bool FuncTry(float x, float y)
        {

            return true;
        }
    }
}
