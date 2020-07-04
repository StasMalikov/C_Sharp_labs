using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_2
{
    class Wu_Pie
    {
        public Bitmap gBitmap { get; set; }
        private Graphics gGraphics { get; set; }
        private Color color = Color.Black;
        private int _height;
        private int _weight;
        private SolidBrush b3;
        private SolidBrush b4;

        public Wu_Pie(int weight, int height)//конструктор
        {
            gBitmap = new Bitmap(weight, height);
            gGraphics = Graphics.FromImage(gBitmap);
            _height = height;
            _weight = weight;
        }

        public Bitmap DrawPie(int x, int y, int a, int b, int startAngle, int endAngle, Color color)
        {
            Color Deep = Color.FromArgb(255, color);
            Color NotDeep = Color.FromArgb(127, color);
            b3 = new SolidBrush(Deep);//насыщенный
            b4 = new SolidBrush(NotDeep);//слабый
            gGraphics.Clear(Color.White);
            int startPart = 0;
            endAngle += startAngle;
            int endPart = 0;

            // определениие частей рисования
            startPart = startAngle / 90 + 1;
            endPart = endAngle / 90 + 1;
            if (endAngle == 360)
            {
                endPart = 4;
            }

            if (endAngle == 270)
            {
                endPart = 3;
            }

            if (endAngle == 90)
            {
                endPart = 1;
            }

            if (startPart == endPart)
            {
                //вызов ф-ии рисования
                switch (startPart)
                {
                    case 1: return FirstPart(gBitmap, x, y, a, b, startAngle, endAngle, true, true);
                    case 2: return SecondPart(gBitmap, x, y, a, b, startAngle, endAngle, true, true);
                    case 3: return ThirdPart(gBitmap, x, y, a, b, startAngle, endAngle, true, true);
                    case 4: return FourthPart(gBitmap, x, y, a, b, startAngle, endAngle, true, true);
                }
            }

            if ((startPart == 1) && (endPart == 2))
            {
                return FirstPart(SecondPart(gBitmap, x, y, a, b, 90, endAngle, false, true),         //2
                                                             x, y, a, b, startAngle, 90, true, false); //1
            }

            if ((startPart == 1) && (endPart == 3))
            {
                return FirstPart(SecondPart(ThirdPart(gBitmap, x, y, a, b, 180, endAngle, false, true),             //3
                                                                    x, y, a, b, 90, 180, false, false),               //2
                                                                            x, y, a, b, startAngle, 90, true, false); //1
            }
            if ((startPart == 1) && (endPart == 4))
            {
                return FirstPart(SecondPart(ThirdPart(FourthPart(gBitmap, x, y, a, b, 270, endAngle, false, true),             //4
                                                                            x, y, a, b, 180, 270, false, false),                 //3
                                                                              x, y, a, b, 90, 180, false, false),                 //2
                                                                                x, y, a, b, startAngle, 90, true, false);         //1
            }
            if ((startPart == 2) && (endPart == 3))
            {
                return SecondPart(ThirdPart(gBitmap, x, y, a, b, 180, endAngle, false, true),       //3
                                                        x, y, a, b, startAngle, 180, true, false);   //2
            }
            if ((startPart == 2) && (endPart == 4))
            {
                return SecondPart(ThirdPart(FourthPart(gBitmap, x, y, a, b, 270, endAngle, false, true),             //4
                                                                            x, y, a, b, 180, 270, false, false),                 //3
                                                                              x, y, a, b, startAngle, 180, true, false);                 //2
            }
            if ((startPart == 3) && (endPart == 4))
            {
                return ThirdPart(FourthPart(gBitmap, x, y, a, b, 270, endAngle, false, true),             //4
                                                             x, y, a, b, startAngle, 270, true, false);                 //3
            }
            return gBitmap;
        }

        private Bitmap FirstPart(Bitmap bitmap, int x, int y, int a, int b, double start, double end, bool pieStart, bool pieEnd)
        {
            SolidBrush b1, b2;
            double start2 = start;
            if (end == 90)
                gGraphics.FillRectangle(new SolidBrush(b3.Color), x, y + b, 1, 1);

            start = (start * Math.PI) / 180;
            end = (end * Math.PI) / 180;
            int start_x = Math.Abs((int)(a * Math.Cos(end))); // Компонента x
            int start_y = Math.Abs((int)(b * Math.Sin(end))); ; // Компонента y
            int end_x = Math.Abs((int)(a * Math.Cos(start))); // Компонента x конца 
            int end_y = Math.Abs((int)(b * Math.Sin(start))); ; // Компонента y конца
            int _y = start_y;
            int _x = start_x;
            int a_sqr = a * a; // a^2, a - большая полуось
            int b_sqr = b * b; // b^2, b - малая полуось
            int delta = 4 * b_sqr * ((_x + 1) * (_x + 1)) + a_sqr * ((2 * _y - 1) * (2 * _y - 1)) - 4 * a_sqr * b_sqr; // Функция координат точки (x+1, y-1/2)

            if (pieEnd)
            {
                bitmap = Line.Wuline(bitmap, x + _x, y + _y, x, y, color); 
            }

            //серединная точка при выборе пикселей
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
                if ((((_y - end_y) > 0) && ((_y - end_y) < 7)) && (((end_x - _x) > 0) && ((end_x - _x) < 7))) //условие выхода
                {

                    if (pieStart)
                    {
                        int dy = 0;
                        if (start2 != 0)
                            dy = _y;
                        bitmap = Line.Wuline(bitmap, x + _x, y + dy, x, y, color);
                    }

                    return bitmap;
                }

                double k = Convert.ToDouble(_y * _y) / b_sqr + Convert.ToDouble(_x * _x) / a_sqr;
                if (k == 1)
                {
                    gGraphics.FillRectangle(new SolidBrush(color), x + _x, y + _y, 1, 1);
                }
                else if (k < 1)//линия ниже чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, b, _x, _y, a_sqr, true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый

                    if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y + _y, 1, 1);//1
                        gGraphics.FillRectangle(b2, x + _x, y + _y + 1, 1, 1);

                    }
                }
                else if (k > 1)//линия выше чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, b, _x, _y, a_sqr, false, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y + _y, 1, 1);//1
                        gGraphics.FillRectangle(b2, x + _x, y + _y - 1, 1, 1);

                    }
                }

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

                if ((((_y - end_y) > 0) && ((_y - end_y) < 7)) && (((end_x - _x) > 0) && ((end_x - _x) < 7))) //условие выхода
                {
                    if (pieStart)
                    {
                        int dy = 0;
                        if (start2 != 0)
                            dy = _y;
                        //bitmap = Line.Bresenham(bitmap, x + _x, y + _y, x, y, color);
                        bitmap = Line.Wuline(bitmap, x + _x, y + dy, x, y, color);
                    }

                    return bitmap;
                }

                double k = Convert.ToDouble(_y * _y) / b_sqr + Convert.ToDouble(_x * _x) / a_sqr;
                if (k == 1)
                {
                    gGraphics.FillRectangle(new SolidBrush(color), x + _x, y + _y, 1, 1);
                }
                else if (k < 1)//линия левее чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, a, _y, _x, b_sqr, true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y + _y, 1, 1);
                        gGraphics.FillRectangle(b2, x + _x + 1, y + _y, 1, 1);//1

                    }
                }
                else if (k > 1)//линия правее чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, a, _y, _x, b_sqr, true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y + _y, 1, 1);
                        gGraphics.FillRectangle(b2, x + _x - 1, y + _y, 1, 1);//1

                    }
                }

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
            if (pieStart)
            {
                int dy = 0;
                if (start2 != 0)
                    dy = _y;
                bitmap = Line.Wuline(bitmap, x + _x, y + dy, x, y, color);
            }

            return bitmap;
        }

        private Bitmap SecondPart(Bitmap bitmap, int x, int y, int a, int b, double start, double end, bool pieStart, bool pieEnd)
        {
            SolidBrush b1, b2;
            double end2 = end;
            if (start == 90)
                gGraphics.FillRectangle(new SolidBrush(b3.Color), x, y + b, 1, 1);
            int falseEnd = (int)end - 90;
            int breakPoint = 0;
            if (falseEnd <= 25)
            {
                breakPoint = 3;
            }

            if ((falseEnd > 25) && (falseEnd < 60))
            {
                breakPoint = 7;
            }

            if ((falseEnd >= 60) && (falseEnd < 80))
            {
                breakPoint = 15;
            }

            start = (start * Math.PI) / 180;
            end = (end * Math.PI) / 180;
            int start_x = Math.Abs((int)(a * Math.Cos(start))); // Компонента x
            int start_y = Math.Abs((int)(b * Math.Sin(start))); ; // Компонента y
            int end_x = Math.Abs((int)(a * Math.Cos(end))); // Компонента x конца 
            int end_y = Math.Abs((int)(b * Math.Sin(end))); ; // Компонента y конца
            int _y = start_y;
            int _x = start_x;
            int a_sqr = a * a; // a^2, a - большая полуось
            int b_sqr = b * b; // b^2, b - малая полуось
            int delta = 4 * b_sqr * ((_x + 1) * (_x + 1)) + a_sqr * ((2 * _y - 1) * (2 * _y - 1)) - 4 * a_sqr * b_sqr; // Функция координат точки (x+1, y-1/2)
            //серединная точка при выборе пиксел

            if (pieStart)
            {
                // bitmap = Line.Bresenham(bitmap, x - _x, y + _y, x, y, color);
                bitmap = Line.Wuline(bitmap, x - _x, y + _y, x, y, color);
            }

            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    if (pieEnd)
                    {
                        int dy = 0;
                        if (end2 != 180)
                            dy = _y;
                        bitmap = Line.Wuline(bitmap, x - _x, y + dy, x, y, color);
                    }

                    return bitmap;
                }
                double k = Convert.ToDouble(_y * _y) / b_sqr + Convert.ToDouble(_x * _x) / a_sqr;
                if (k == 1)
                {
                    gGraphics.FillRectangle(new SolidBrush(color), x - _x, y + _y, 1, 1);
                }
                else if (k < 1)//линия ниже чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, b, _x, _y, a_sqr, true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y + _y, 1, 1);//2
                        gGraphics.FillRectangle(b2, x - _x, y + _y + 1, 1, 1);
                    }
                }
                else if (k > 1)//линия выше чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, b, _x, _y, a_sqr, false, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    
                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y + _y, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x, y + _y - 1, 1, 1);//2
                    }
                }
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
                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    if (pieEnd)
                    {
                        int dy = 0;
                        if (end2 != 180)
                            dy = _y;
                        // bitmap = Line.Bresenham(bitmap, x - _x, y + _y, x, y, color);
                        bitmap = Line.Wuline(bitmap, x - _x, y + dy, x, y, color);
                    }

                    return bitmap;
                }
                double k = Convert.ToDouble(_y * _y) / b_sqr + Convert.ToDouble(_x * _x) / a_sqr;
                if (k == 1)
                {
                    gGraphics.FillRectangle(new SolidBrush(color), x - _x, y + _y, 1, 1);
                }
                else if (k < 1)//линия левее чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, a, _y, _x, b_sqr, true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y + _y, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x - 1, y + _y, 1, 1);//2
                    }
                }
                else if (k > 1)//линия правее чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, a, _y, _x, b_sqr, true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y + _y, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x + 1, y + _y, 1, 1);//2
                    }
                }
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
            if (pieEnd)
            {
                int dy = 0;
                if (end2 != 180)
                    dy = _y;
                // bitmap = Line.Bresenham(bitmap, x - _x, y + _y, x, y, color);
                bitmap = Line.Wuline(bitmap, x - _x, y + dy, x, y, color);
            }

            return bitmap;
        }
        private Bitmap ThirdPart(Bitmap bitmap, int x, int y, int a, int b, double start, double end, bool pieStart, bool pieEnd)
        {
            SolidBrush b1, b2;
            double start2 = start;
            if (end == 270)
                gGraphics.FillRectangle(new SolidBrush(b3.Color), x, y - b, 1, 1);
            start = (start * Math.PI) / 180;
            end = (end * Math.PI) / 180;
            int start_x = Math.Abs((int)(a * Math.Cos(end))); // Компонента x
            int start_y = Math.Abs((int)(b * Math.Sin(end))); ; // Компонента y
            int end_x = Math.Abs((int)(a * Math.Cos(start))); // Компонента x конца 
            int end_y = Math.Abs((int)(b * Math.Sin(start))); ; // Компонента y конца
            int _y = start_y;
            int _x = start_x;
            int a_sqr = a * a; // a^2, a - большая полуось
            int b_sqr = b * b; // b^2, b - малая полуось
            int delta = 4 * b_sqr * ((_x + 1) * (_x + 1)) + a_sqr * ((2 * _y - 1) * (2 * _y - 1)) - 4 * a_sqr * b_sqr; // Функция координат точки (x+1, y-1/2)
                                                                                                                       //серединная точка при выборе пикселей
            if (pieEnd)
            {
                //bitmap = Line.Bresenham(bitmap, x - _x, y - _y, x, y, color);
                bitmap = Line.Wuline(bitmap, x - _x, y - _y, x, y, color);
            }

            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
                if ((((_y - end_y) > 0) && ((_y - end_y) < 7)) && (((end_x - _x) > 0) && ((end_x - _x) < 7))) //условие выхода
                {
                    if (pieStart)
                    {
                        int dy = 0;
                        if (start2 != 180)
                            dy = _y;
                        bitmap = Line.Wuline(bitmap, x - _x, y - dy, x, y, color);
                    }
                    return bitmap;
                }
                double k = Convert.ToDouble(_y * _y) / b_sqr + Convert.ToDouble(_x * _x) / a_sqr;
                if (k == 1)
                {
                    gGraphics.FillRectangle(new SolidBrush(color), x - _x, y - _y, 1, 1);
                }
                else if (k < 1)//линия ниже чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, b, _x, _y, a_sqr, true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый

                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y - _y, 1, 1);//3
                        gGraphics.FillRectangle(b2, x - _x, y - _y - 1, 1, 1);
                    }
                }
                else if (k > 1)//линия выше чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, b, _x, _y, a_sqr, false, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y - _y, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x, y - _y + 1, 1, 1);//3
                    }
                }
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

                if ((((_y - end_y) > 0) && ((_y - end_y) < 7)) && (((end_x - _x) > 0) && ((end_x - _x) < 7))) //условие выхода
                {
                    if (pieStart)
                    {
                        int dy = 0;
                        if (start2 != 180)
                            dy = _y;
                        bitmap = Line.Wuline(bitmap, x - _x, y - dy, x, y, color);
                    }
                    return bitmap;
                }
                double k = Convert.ToDouble(_y * _y) / b_sqr + Convert.ToDouble(_x * _x) / a_sqr;
                if (k == 1)
                {
                    gGraphics.FillRectangle(new SolidBrush(color), x - _x, y - _y, 1, 1);
                }
                else if (k < 1)//линия левее чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, a, _y, _x, b_sqr, true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b2, x - _x, y - _y, 1, 1);
                        gGraphics.FillRectangle(b1, x - _x - 1, y - _y, 1, 1);//3
                    }
                }
                else if (k > 1)//линия правее чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, a, _y, _x, b_sqr, true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y - _y, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x + 1, y - _y, 1, 1);//3
                    }
                }
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
            if (pieStart)
            {
                int dy = 0;
                if (start2 != 180)
                    dy = _y;
                bitmap = Line.Wuline(bitmap, x - _x, y - dy, x, y, color);
            }

            return bitmap;
        }
        private Bitmap FourthPart(Bitmap bitmap, int x, int y, int a, int b, double start, double end, bool pieStart, bool pieEnd)
        {
            SolidBrush b1, b2;
            double end2 = end;

            if (start == 270)
                gGraphics.FillRectangle(new SolidBrush(b3.Color), x, y - b, 1, 1);
            int falseEnd = (int)end - 270;
            int breakPoint = 0;
            if (falseEnd <= 25)
            {
                breakPoint = 3;
            }

            if ((falseEnd > 25) && (falseEnd < 60))
            {
                breakPoint = 7;
            }

            if ((falseEnd >= 60) && (falseEnd < 80))
            {
                breakPoint = 15;
            }

            start = (start * Math.PI) / 180;
            end = (end * Math.PI) / 180;
            int start_x = Math.Abs((int)(a * Math.Cos(start))); // Компонента x
            int start_y = Math.Abs((int)(b * Math.Sin(start)));// Компонента y
            int end_x = Math.Abs((int)(a * Math.Cos(end)));// Компонента x конца 
            int end_y = Math.Abs((int)(b * Math.Sin(end))); // Компонента y конца
            int _y = start_y;
            int _x = start_x;
            int a_sqr = a * a; // a^2, a - большая полуось
            int b_sqr = b * b; // b^2, b - малая полуось
            int delta = 4 * b_sqr * ((_x + 1) * (_x + 1)) + a_sqr * ((2 * _y - 1) * (2 * _y - 1)) - 4 * a_sqr * b_sqr; // Функция координат точки (x+1, y-1/2)
                                                                                                                       //серединная точка при выборе пикселей
            if (pieStart)
            {
                //bitmap = Line.Bresenham(bitmap, x + _x, y - _y, x, y, color);
                bitmap = Line.Wuline(bitmap, x + _x, y - _y, x, y, color);
            }

            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем

                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    if (pieEnd)
                    {
                        int dy = 0;
                        if (end2 != 360)
                            dy = _y;
                        bitmap = Line.Wuline(bitmap, x + _x, y - _y, x, y, color);
                    }

                    return bitmap;
                }
                double k = Convert.ToDouble(_y * _y) / b_sqr + Convert.ToDouble(_x * _x) / a_sqr;
                if (k == 1)
                {
                    gGraphics.FillRectangle(new SolidBrush(color), x + _x, y - _y, 1, 1);
                }
                else if (k < 1)//линия ниже чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, b, _x, _y, a_sqr, true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый

                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y - _y, 1, 1);//4
                        gGraphics.FillRectangle(b2, x + _x, y - _y - 1, 1, 1);
                    }
                }
                else if (k > 1)//линия выше чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, b, _x, _y, a_sqr, false, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый

                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y - _y, 1, 1);
                        gGraphics.FillRectangle(b2, x + _x, y - _y + 1, 1, 1);//4
                    }
                }
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

                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    if (pieEnd)
                    {
                        int dy = 0;
                        if (end2 != 360)
                            dy = _y;
                        bitmap = Line.Wuline(bitmap, x + _x, y - _y, x, y, color);
                    }

                    return bitmap;
                }
                double k = Convert.ToDouble(_y * _y) / b_sqr + Convert.ToDouble(_x * _x) / a_sqr;
                if (k == 1)
                {
                    gGraphics.FillRectangle(new SolidBrush(color), x + _x, y - _y, 1, 1);
                }
                else if (k < 1)//линия левее чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, a, _y, _x, b_sqr, true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b2, x + _x, y - _y, 1, 1);
                        gGraphics.FillRectangle(b1, x + _x + 1, y - _y, 1, 1);//4
                    }
                }
                else if (k > 1)//линия правее чем надо
                {
                    Color c2;
                    Color c1 = SetColor(out c2, a, _y, _x, b_sqr, true, color);

                    b1 = new SolidBrush(c1);//насыщенный
                    b2 = new SolidBrush(c2);//слабый
                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y - _y, 1, 1);
                        gGraphics.FillRectangle(b2, x + _x - 1, y - _y, 1, 1);//4
                    }
                }

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
            if (pieEnd)
            {
                int dy = 0;
                if (end2 != 360)
                    dy = _y;
                bitmap = Line.Wuline(bitmap, x + _x, y - _y, x, y, color);
            }

            return bitmap;
        }
        static Color SetColor(out Color c2, int b, int x1, int y1, int a_sqr, bool bo, Color color)
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
