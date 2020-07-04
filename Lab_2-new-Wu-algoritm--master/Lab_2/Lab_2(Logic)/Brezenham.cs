using System.Drawing;

namespace Lab_2
{
    public class Brezenham
    {
        public Bitmap gBitmap { get; set; }
        public Graphics gGraphics { get; set; }

        private Color color = Color.Black;
        private int _height;
        private int _weight;

        public Brezenham(int weight, int height)//конструктор
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
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                DrawEllipseSupport(x, _x, y, _y);//рисуем

                if (delta < 0) // Переход по горизонтали
                {
                    _x++;
                    delta += 4 * b_sqr * (2 * _x + 3);
                }
                else // Переход по диагонали
                {
                    _x++;
                    delta = delta - 8 * a_sqr * (_y - 1) + 4 * b_sqr * (2 * _x + 3);
                    _y--;
                }
            }

            delta = b_sqr * ((2 * _x + 1) * (2 * _x + 1)) + 4 * a_sqr * ((_y + 1) * (_y + 1)) - 4 * a_sqr * b_sqr; // Функция координат точки (x+1/2, y-1)

            while (_y + 1 != 0) // Вторая часть дуги, если не выполняется условие первого цикла, значит выполняется a^2(2y - 1) <= 2b^2(x + 1)
            {
                DrawEllipseSupport(x, _x, y, _y);//рисуем

                if (delta < 0) // Переход по вертикали
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
        private void DrawEllipseSupport(int x, int _x, int y, int _y)
        {
            if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
            {
                gBitmap.SetPixel(x + _x, y + _y, color);//1
            }
            if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
            {
                gBitmap.SetPixel(x + _x, y - _y, color);//4
            }
            if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
            {
                gBitmap.SetPixel(x - _x, y - _y, color);//3
            }
            if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
            {
                gBitmap.SetPixel(x - _x, y + _y, color);//2
            }
        }

    }
}
