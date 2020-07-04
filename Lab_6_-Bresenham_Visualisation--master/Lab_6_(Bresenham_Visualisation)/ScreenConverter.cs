using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Lab_6__Bresenham_Visualisation_
{
   public class ScreenConverter
    {
        public static int I1 = 0, J1 = 0, I2, J2;

        public double x1 = -20, y1 = -10, x2 = 20, y2 = 21.5;
        public ScreenConverter(Rectangle ClientRectangle)
        {
            I2 = ClientRectangle.Width;
            J2 = ClientRectangle.Height;
        }

        public int II(double x)//на сдвиг
        {
            return I1 + (int)((x - x1) * (I2 - I1) / (x2 - x1));
        }

        public double XX(int I)//на приблежение-отдаление //обратное преобразованиие
        {
            return x1 + (I - I1) * (x2 - x1) / (I2 - I1);
        }

        public int JJ(double y)//на сдвиг
        {
            return J2 + (int)((y - y1) * (J1 - J2) / (y2 - y1));
        }

        public double YY(int J)//на приблежение-отдаление  //обратное преобразование
        {
            return y1 + (J - J2) * (y2 - y1) / (J1 - J2);
        }
    }
}
