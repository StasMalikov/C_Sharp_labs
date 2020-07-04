using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_2
{
   public class Wu
    {
        public Bitmap gBitmap { get; set; }
        public Graphics gGraphics { get; set; }
        
        private int _height;
        private int _weight;
        public Wu(int weight, int height)//конструктор
        {
            gBitmap = new Bitmap(weight, height);
            gGraphics = Graphics.FromImage(gBitmap);
            _height = height;
            _weight = weight;
        }
        public Bitmap DrawEllipse(int x, int y, int a, int b, Color color)
        {
            gGraphics.Clear(Color.White);
            int _x = 0; // Компонента x
            int _y = b; // Компонента y
            int a_sqr = a * a; // a^2, a - большая полуось
            int b_sqr = b * b; // b^2, b - малая полуось
            
            int delta = 4 * b_sqr * ((_x + 1) * (_x + 1)) + a_sqr * ((2 * _y - 1) * (2 * _y - 1)) - 4 * a_sqr * b_sqr; // Функция координат точки (x+1, y-1/2)
            //серединная точка при выборе пикселей
            SolidBrush b1, b2;
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                double k = Convert.ToDouble(_y * _y) / b_sqr + Convert.ToDouble(_x * _x) / a_sqr;
                if (k == 1)
                {
                    gGraphics.FillRectangle(new SolidBrush(color), x + _x, y + _y, 1, 1);
                    gGraphics.FillRectangle(new SolidBrush(color), x - _x, y + _y, 1, 1);
                    gGraphics.FillRectangle(new SolidBrush(color), x + _x, y - _y, 1, 1);
                    gGraphics.FillRectangle(new SolidBrush(color), x - _x, y - _y, 1, 1);
                }
                else if (k < 1)//линия ниже чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, b, _x, _y, a_sqr,  true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый

                    if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y + _y, 1, 1);//1
                        gGraphics.FillRectangle(b2, x + _x, y + _y + 1, 1, 1);

                    }
                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y - _y , 1, 1);//4
                        gGraphics.FillRectangle(b2, x + _x, y - _y - 1, 1, 1);
                    }
                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y - _y , 1, 1);//3
                        gGraphics.FillRectangle(b2, x - _x, y - _y - 1, 1, 1);
                    }
                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y + _y, 1, 1);//2
                        gGraphics.FillRectangle(b2, x - _x, y + _y + 1, 1, 1);
                    }

                    //Pixel(bmp, x, y, x1, y1, c1);
                    //Pixel(bmp, x, y, x1, y1 + 1, c2);
                }
                else if (k > 1)//линия выше чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, b, _x, _y, a_sqr,  false, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y + _y, 1, 1);//1
                        gGraphics.FillRectangle(b2, x + _x, y + _y -1, 1, 1);

                    }
                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y - _y , 1, 1);
                        gGraphics.FillRectangle(b2, x + _x, y - _y + 1, 1, 1);//4
                    }
                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y - _y , 1, 1);
                        gGraphics.FillRectangle(b2, x - _x, y - _y + 1, 1, 1);//3
                    }
                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y + _y , 1, 1);
                        gGraphics.FillRectangle(b2, x - _x, y + _y - 1, 1, 1);//2
                    }
                    //Pixel(bmp, x, y, x1, y1, c1);
                    //Pixel(bmp, x, y, x1, y1 - 1, c2);

                    
                }
                if (delta < 0) // Переход по горизонтали------------------------------------------------------------------------
                {
                    _x++;
                    delta += 4 * b_sqr * (2 * _x + 3);
                }
                else // Переход по диагонали-----------------------------------------------------------------------------
                {      
                    _x++;
                    delta = delta - 8 * a_sqr * (_y - 1) + 4 * b_sqr * (2 * _x + 3);
                    _y--;
                }
            }

            delta = b_sqr * ((2 * _x + 1) * (2 * _x + 1)) + 4 * a_sqr * ((_y + 1) * (_y + 1)) - 4 * a_sqr * b_sqr; // Функция координат точки (x+1/2, y-1)

            while (_y +1!= 0) // Вторая часть дуги, если не выполняется условие первого цикла, значит выполняется a^2(2y - 1) <= 2b^2(x + 1)
            {
                double k = Convert.ToDouble(_y * _y) / b_sqr + Convert.ToDouble(_x * _x) / a_sqr;
                if (k == 1)
                {
                    gGraphics.FillRectangle(new SolidBrush(color), x + _x, y + _y, 1, 1);
                    gGraphics.FillRectangle(new SolidBrush(color), x - _x, y + _y, 1, 1);
                    gGraphics.FillRectangle(new SolidBrush(color), x + _x, y - _y, 1, 1);
                    gGraphics.FillRectangle(new SolidBrush(color), x - _x, y - _y, 1, 1);
                }
                else if (k < 1)//линия левее чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, a, _y, _x, b_sqr,  true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x , y + _y, 1, 1);
                        gGraphics.FillRectangle(b2, x + _x + 1, y + _y , 1, 1);//1

                    }
                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b2, x + _x , y - _y, 1, 1);
                        gGraphics.FillRectangle(b1, x + _x + 1, y - _y, 1, 1);//4
                    }
                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b2, x - _x , y - _y, 1, 1);
                        gGraphics.FillRectangle(b1, x - _x - 1, y - _y, 1, 1);//3
                    }
                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x , y + _y, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x - 1, y + _y, 1, 1);//2
                    }
                    //Pixel(bmp, x, y, x1, y1, c1);
                    //Pixel(bmp, x, y, x1 + 1, y1, c2);
                }
                else if (k > 1)//линия правее чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, a, _y, _x, b_sqr, true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x , y + _y, 1, 1);
                        gGraphics.FillRectangle(b2, x + _x - 1, y + _y , 1, 1);//1

                    }
                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x , y - _y, 1, 1);
                        gGraphics.FillRectangle(b2, x + _x - 1, y - _y, 1, 1);//4
                    }
                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x , y - _y, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x + 1, y - _y, 1, 1);//3
                    }
                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x , y + _y, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x + 1, y + _y, 1, 1);//2
                    }
                    //Pixel(bmp, x, y, x1, y1, c1);
                    //Pixel(bmp, x, y, x1 - 1, y1, c2);
                }


                if (delta < 0) // Переход по вертикали----------------------------------------------------------------------
                {
                    _y--;
                    delta += 4 * a_sqr * (2 * _y + 3);
                }
                else // Переход по диагонали
                {
                    _y--;
                    delta += (-8 * b_sqr * (_x + 1) + 4 * a_sqr * (2 * _y + 3));
                    _x++;
                }
            }
            gGraphics.Dispose();
            return gBitmap;
        }

        static Color SetColor(out Color c2, int b, int x1, int y1, int a_sqr,  bool bo, Color color)
        {
            double n = b * Math.Sqrt(1 - Convert.ToDouble(x1 * x1) / a_sqr);
            double d = Math.Abs(y1 - n);
            if (d > 1)
            {
                if (bo)
                    y1++;
                else
                    y1--;
                d = d - Math.Truncate(d);
            }

            int n1 = Math.Abs(Convert.ToInt32((1 - d) * 255));
            int n2 = Math.Abs(Convert.ToInt32(d * 255));


            Color c1 = Color.FromArgb(n1, color);
            c2 = Color.FromArgb(n2, color);
            if (n2 > n1)
            {
                c2 = Color.FromArgb(n1, color);
                c1 = Color.FromArgb(n2, color);
            }
            return c1;
        }
    }
}
