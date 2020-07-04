using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab_4_test_
{
    public class F1 : IFunc
    {
        public float F(float x, float y)
        {
            return (float)(Math.Pow(Math.E, Math.Sin(3 * x)) - Math.Cos(y * y));
        }
        public bool FuncTry(float x, float y)
        {

            return true;
        }
    }
}
