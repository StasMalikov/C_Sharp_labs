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
            gGraphics.FillRectangle(new SolidBrush(Color.Black), x, y-b , 1, 1);
            gGraphics.FillRectangle(new SolidBrush(Color.Black), x, y + b, 1, 1);
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                if (delta < 0) // Переход по горизонтали------------------------------------------------------------------------
                {
                    int Dx = _x - x;
                    int Dy = _y - y;
                    int e = 2 * Dy - Dx;
                    float   d = -1F * e / (Dy + Dx) / 1.15F;
                    b1 = new SolidBrush(SetColor(Math.Abs( 1F / 2 - d)));//насыщенный
                    b2 = new SolidBrush(SetColor(Math.Abs(1F / 2 + d)));//слабый
                    _x++;
                    delta += 4 * b_sqr * (2 * _x + 3);

                    if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y + _y ,                  1, 1);//1
                        gGraphics.FillRectangle(b2, x + _x, y + _y + 1,                  1, 1);

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
                        gGraphics.FillRectangle(b1, x - _x, y + _y , 1, 1);//2
                        gGraphics.FillRectangle(b2, x - _x, y + _y - 1, 1, 1);
                    }
                }
                else // Переход по диагонали-----------------------------------------------------------------------------
                {
                    int Dx = _x - x;
                    int Dy = _y - y;
                    int e = 2 * Dy - Dx;
                    float d = -1F * e / (Dy + Dx) / 1.15F;
                    b1 = new SolidBrush(SetColor(Math.Abs(1F / 2 + d)));//насыщенный
                    b2 = new SolidBrush(SetColor(Math.Abs(1F / 2 - d)));//слабый
                    _x++;
                    delta = delta - 8 * a_sqr * (_y - 1) + 4 * b_sqr * (2 * _x + 3);
                    _y--;

                    if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y + _y, 1, 1);//1
                        gGraphics.FillRectangle(b2, x + _x, y + _y + 1, 1, 1);

                    }
                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y - _y - 1, 1, 1);
                        gGraphics.FillRectangle(b2, x + _x, y - _y, 1, 1);//4
                    }
                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y - _y - 1, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x, y - _y, 1, 1);//3
                    }
                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y + _y - 1, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x, y + _y, 1, 1);//2
                    }
                }
            }

            delta = b_sqr * ((2 * _x + 1) * (2 * _x + 1)) + 4 * a_sqr * ((_y + 1) * (_y + 1)) - 4 * a_sqr * b_sqr; // Функция координат точки (x+1/2, y-1)

            while (_y +1!= 0) // Вторая часть дуги, если не выполняется условие первого цикла, значит выполняется a^2(2y - 1) <= 2b^2(x + 1)
            {
                if (delta < 0) // Переход по вертикали----------------------------------------------------------------------
                {

                    int Dx = _x - x;
                    int Dy = _y - y;
                    int e = 2 * Dy - Dx;
                    float d = -1F * e / (Dy + Dx) / 1.15F;
                    b1 = new SolidBrush(SetColor(Math.Abs(1F / 2 - d)));//насыщенный
                    b2 = new SolidBrush(SetColor(Math.Abs(1F / 2 + d)));//слабый
                    _y--;
                    delta += 4 * a_sqr * (2 * _y + 3);

                    if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x , y + _y , 1, 1);
                        gGraphics.FillRectangle(b2, x + _x + 1, y + _y , 1, 1);//1

                    }
                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b2, x + _x , y - _y , 1, 1);
                        gGraphics.FillRectangle(b1, x + _x - 1, y - _y , 1, 1);//4
                    }
                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b2, x - _x , y - _y , 1, 1);
                        gGraphics.FillRectangle(b1, x - _x + 1, y - _y , 1, 1);//3
                    }
                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x , y + _y , 1, 1);
                        gGraphics.FillRectangle(b2, x - _x + 1, y + _y , 1, 1);//2
                    }
                    
                }
                else // Переход по диагонали
                {

                    int Dx = _x - x;
                    int Dy = _y - y;
                    int e = 2 * Dy - Dx;
                    float d = -1F * e / (Dy + Dx) / 1.15F;
                    b1 = new SolidBrush(SetColor(Math.Abs(1F / 2 + d)));//насыщенный
                    b2 = new SolidBrush(SetColor(Math.Abs(1F / 2 - d)));//слабый
                    _y--;
                    delta += (-8 * b_sqr * (_x + 1) + 4 * a_sqr * (2 * _y + 3));
                    _x++;
                    if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x + 1, y + _y , 1, 1);
                        gGraphics.FillRectangle(b2, x + _x , y + _y , 1, 1);//1

                    }
                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x - 1, y - _y , 1, 1);
                        gGraphics.FillRectangle(b2, x + _x , y - _y , 1, 1);//4
                    }
                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x + 1, y - _y , 1, 1);
                        gGraphics.FillRectangle(b2, x - _x , y - _y , 1, 1);//3
                    }
                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x + 1, y + _y , 1, 1);
                        gGraphics.FillRectangle(b2, x - _x, y + _y , 1, 1);//2
                    } 
                }
            }
            gGraphics.Dispose();
            return gBitmap;
        }
        private static Color SetColor(float t)
        {
            int c = Convert.ToInt32(255 * t);
            if (c > 255)
                c = 255;
            Color res = Color.FromArgb(c, c, c);
            return res;
        }
    }
}
