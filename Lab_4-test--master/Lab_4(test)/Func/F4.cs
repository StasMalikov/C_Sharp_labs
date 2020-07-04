using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_4_test_
{
   public class F4: IFunc
    {
        public float F(float x, float y)
        {
            return (float)Math.Log(x * x + 1) / (y * y + 2);
        }
        public bool FuncTry(float x, float y)
        {
            return true;
        }
    }
}
