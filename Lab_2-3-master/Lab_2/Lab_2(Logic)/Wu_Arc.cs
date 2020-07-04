using System;
using System.Drawing;

namespace Lab_2
{
    public class Wu_Arc
    {
        public Bitmap gBitmap { get; set; }
        private Graphics gGraphics { get; set; }
        private int _height;
        private int _weight;
        private SolidBrush b3;
        private SolidBrush b4;

        public Wu_Arc(int weight, int height)//конструктор
        {
            gBitmap = new Bitmap(weight, height);
            gGraphics = Graphics.FromImage(gBitmap);
            _height = height;
            _weight = weight;
        }
        //gGraphics.FillRectangle(new SolidBrush(color), x, y-b , 1, 1);
        //    gGraphics.FillRectangle(new SolidBrush(color), x, y + b, 1, 1);

        public Bitmap DrawArc(int x, int y, int a, int b, int startAngle, int endAngle, Color color)
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
                    case 1: return FirstPart(gBitmap, x, y, a, b, startAngle, endAngle);
                    case 2: return SecondPart(gBitmap, x, y, a, b, startAngle, endAngle);
                    case 3: return ThirdPart(gBitmap, x, y, a, b, startAngle, endAngle);
                    case 4: return FourthPart(gBitmap, x, y, a, b, startAngle, endAngle);
                }
            }

            if ((startPart == 1) && (endPart == 2))
            {
                return FirstPart(SecondPart(gBitmap, x, y, a, b, 90, endAngle),         //2
                                                             x, y, a, b, startAngle, 90); //1
            }

            if ((startPart == 1) && (endPart == 3))
            {
                return FirstPart(SecondPart(ThirdPart(gBitmap, x, y, a, b, 180, endAngle),             //3
                                                                    x, y, a, b, 90, 180),               //2
                                                                            x, y, a, b, startAngle, 90); //1
            }
            if ((startPart == 1) && (endPart == 4))
            {
                return FirstPart(SecondPart(ThirdPart(FourthPart(gBitmap, x, y, a, b, 270, endAngle),             //4
                                                                            x, y, a, b, 180, 270),                 //3
                                                                              x, y, a, b, 90, 180),                 //2
                                                                                x, y, a, b, startAngle, 90);         //1
            }
            if ((startPart == 2) && (endPart == 3))
            {
                return SecondPart(ThirdPart(gBitmap, x, y, a, b, 180, endAngle),       //3
                                                        x, y, a, b, startAngle, 180);   //2
            }
            if ((startPart == 2) && (endPart == 4))
            {
                return SecondPart(ThirdPart(FourthPart(gBitmap, x, y, a, b, 270, endAngle),             //4
                                                                            x, y, a, b, 180, 270),                 //3
                                                                              x, y, a, b, startAngle, 180);                 //2
            }
            if ((startPart == 3) && (endPart == 4))
            {
                return ThirdPart(FourthPart(gBitmap, x, y, a, b, 270, endAngle),             //4
                                                             x, y, a, b, startAngle, 270);                 //3
            }
            return gBitmap;
        }

        private Bitmap FirstPart(Bitmap bitmap, int x, int y, int a, int b, double start, double end)
        {
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
            SolidBrush b1, b2;

            //серединная точка при выборе пикселей
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
                
                if ((((_y - end_y) > 0) && ((_y - end_y) < 7)) && (((end_x - _x) > 0) && ((end_x - _x) < 7))) //условие выхода
                {
                    return bitmap;
                }

                if (delta < 0) // Переход по горизонтали
                {
                    int Dx = _x - x;
                    int Dy = _y - y;
                    int e = 2 * Dy - Dx;
                    float d = -1F * e / (Dy + Dx) / 1.15F;
                    b1 = new SolidBrush(SetColor(Math.Abs(1F / 2 - d)));//насыщенный
                    b2 = new SolidBrush(SetColor(Math.Abs(1F / 2 + d)));//слабый
                    _x++;
                    delta += 4 * b_sqr * (2 * _x + 3);

                    if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y + _y, 1, 1);//1
                        gGraphics.FillRectangle(b2, x + _x, y + _y + 1, 1, 1);
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
                    _x++;
                    delta = delta - 8 * a_sqr * (_y - 1) + 4 * b_sqr * (2 * _x + 3);
                    _y--;

                    if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y + _y, 1, 1);//1
                        gGraphics.FillRectangle(b2, x + _x, y + _y + 1, 1, 1);
                    }
                }
            }

            delta = b_sqr * ((2 * _x + 1) * (2 * _x + 1)) + 4 * a_sqr * ((_y + 1) * (_y + 1)) - 4 * a_sqr * b_sqr; // Функция координат точки (x+1/2, y-1)

            while (_y + 1 != 0) // Вторая часть дуги, если не выполняется условие первого цикла, значит выполняется a^2(2y - 1) <= 2b^2(x + 1)
            {
                

                if ((((_y - end_y) > 0) && ((_y - end_y) < 7)) && (((end_x - _x) > 0) && ((end_x - _x) < 7))) //условие выхода
                {
                    return bitmap;
                }
                if (delta < 0) // Переход по вертикали
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
                        gGraphics.FillRectangle(b1, x + _x, y + _y, 1, 1);
                        gGraphics.FillRectangle(b2, x + _x + 1, y + _y, 1, 1);//1
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
                        gGraphics.FillRectangle(b1, x + _x + 1, y + _y, 1, 1);
                        gGraphics.FillRectangle(b2, x + _x, y + _y, 1, 1);//1
                    }
                }
            }
            return bitmap;
        }

        private Bitmap SecondPart(Bitmap bitmap, int x, int y, int a, int b, double start, double end)
        {
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
            SolidBrush b1, b2;                                                                                //серединная точка при выборе пиксел
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    return bitmap;
                }

                if (delta < 0) // Переход по горизонтали
                {
                    int Dx = _x - x;
                    int Dy = _y - y;
                    int e = 2 * Dy - Dx;
                    float d = -1F * e / (Dy + Dx) / 1.15F;
                    b1 = new SolidBrush(SetColor(Math.Abs(1F / 2 - d)));//насыщенный
                    b2 = new SolidBrush(SetColor(Math.Abs(1F / 2 + d)));//слабый
                    _x++;
                    delta += 4 * b_sqr * (2 * _x + 3);

                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y + _y, 1, 1);//2
                        gGraphics.FillRectangle(b2, x - _x, y + _y - 1, 1, 1);
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
                    _x++;
                    delta = delta - 8 * a_sqr * (_y - 1) + 4 * b_sqr * (2 * _x + 3);
                    _y--;

                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y + _y - 1, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x, y + _y, 1, 1);//2
                    }
                }
            }

            delta = b_sqr * ((2 * _x + 1) * (2 * _x + 1)) + 4 * a_sqr * ((_y + 1) * (_y + 1)) - 4 * a_sqr * b_sqr; // Функция координат точки (x+1/2, y-1)

            while (_y + 1 != 0) // Вторая часть дуги, если не выполняется условие первого цикла, значит выполняется a^2(2y - 1) <= 2b^2(x + 1)
            {
                
                //(((_y-end_y)>0) &&((_y - end_y)<5))  &&  (((end_x-_x)>0)&&((end_x - _x)<5))
                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    return bitmap;
                }

                if (delta < 0) // Переход по вертикали
                {
                    int Dx = _x - x;
                    int Dy = _y - y;
                    int e = 2 * Dy - Dx;
                    float d = -1F * e / (Dy + Dx) / 1.15F;
                    b1 = new SolidBrush(SetColor(Math.Abs(1F / 2 - d)));//насыщенный
                    b2 = new SolidBrush(SetColor(Math.Abs(1F / 2 + d)));//слабый
                    _y--;
                    delta += 4 * a_sqr * (2 * _y + 3);

                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y + _y, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x + 1, y + _y, 1, 1);//2
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

                    if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x + 1, y + _y, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x, y + _y, 1, 1);//2
                    }
                }
            }
            return bitmap;
        }
        private Bitmap ThirdPart(Bitmap bitmap, int x, int y, int a, int b, double start, double end)
        {
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

            int falseEnd = (int)end - 180;
            int breakPoint = 0;
            if (falseEnd <= 25)
                breakPoint = 0;
            if ((falseEnd > 25) && (falseEnd < 60))
                breakPoint = 7;
            SolidBrush b1, b2;

            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
               
                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    return bitmap;
                }

                if (delta < 0) // Переход по горизонтали
                {
                    int Dx = _x - x;
                    int Dy = _y - y;
                    int e = 2 * Dy - Dx;
                    float d = -1F * e / (Dy + Dx) / 1.15F;
                    b1 = new SolidBrush(SetColor(Math.Abs(1F / 2 - d)));//насыщенный
                    b2 = new SolidBrush(SetColor(Math.Abs(1F / 2 + d)));//слабый
                    _x++;
                    delta += 4 * b_sqr * (2 * _x + 3);

                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y - _y, 1, 1);//3
                        gGraphics.FillRectangle(b2, x - _x, y - _y - 1, 1, 1);
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
                    _x++;
                    delta = delta - 8 * a_sqr * (_y - 1) + 4 * b_sqr * (2 * _x + 3);
                    _y--;

                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x, y - _y - 1, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x, y - _y, 1, 1);//3
                    }
                }
            }

            delta = b_sqr * ((2 * _x + 1) * (2 * _x + 1)) + 4 * a_sqr * ((_y + 1) * (_y + 1)) - 4 * a_sqr * b_sqr; // Функция координат точки (x+1/2, y-1)

            while (_y + 1 != 0) // Вторая часть дуги, если не выполняется условие первого цикла, значит выполняется a^2(2y - 1) <= 2b^2(x + 1)
            {
                //if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                //{
                //    gGraphics.FillRectangle(b1, x - _x, y - _y, 1, 1);
                //    gGraphics.FillRectangle(b2, x - _x + 1, y - _y, 1, 1);//3
                //}

                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    return bitmap;
                }

                if (delta < 0) // Переход по вертикали
                {
                    int Dx = _x - x;
                    int Dy = _y - y;
                    int e = 2 * Dy - Dx;
                    float d = -1F * e / (Dy + Dx) / 1.15F;
                    b1 = new SolidBrush(SetColor(Math.Abs(1F / 2 - d)));//насыщенный
                    b2 = new SolidBrush(SetColor(Math.Abs(1F / 2 + d)));//слабый
                    _y--;
                    delta += 4 * a_sqr * (2 * _y + 3);

                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b2, x - _x, y - _y, 1, 1);
                        gGraphics.FillRectangle(b1, x - _x + 1, y - _y, 1, 1);//3
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

                    if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x - _x + 1, y - _y, 1, 1);
                        gGraphics.FillRectangle(b2, x - _x, y - _y, 1, 1);//3
                    }
                }
            }
            return bitmap;
        }
        private Bitmap FourthPart(Bitmap bitmap, int x, int y, int a, int b, double start, double end)
        {
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
            SolidBrush b1, b2;                                                                                                 //серединная точка при выборе пикселей
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
               

                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    return bitmap;
                }

                if (delta < 0) // Переход по горизонтали
                {
                    int Dx = _x - x;
                    int Dy = _y - y;
                    int e = 2 * Dy - Dx;
                    float d = -1F * e / (Dy + Dx) / 1.15F;
                    b1 = new SolidBrush(SetColor(Math.Abs(1F / 2 - d)));//насыщенный
                    b2 = new SolidBrush(SetColor(Math.Abs(1F / 2 + d)));//слабый
                    _x++;
                    delta += 4 * b_sqr * (2 * _x + 3);

                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y - _y, 1, 1);//4
                        gGraphics.FillRectangle(b2, x + _x, y - _y - 1, 1, 1);
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
                    _x++;
                    delta = delta - 8 * a_sqr * (_y - 1) + 4 * b_sqr * (2 * _x + 3);
                    _y--;

                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x, y - _y - 1, 1, 1);
                        gGraphics.FillRectangle(b2, x + _x, y - _y, 1, 1);//4
                    }
                }
            }

            delta = b_sqr * ((2 * _x + 1) * (2 * _x + 1)) + 4 * a_sqr * ((_y + 1) * (_y + 1)) - 4 * a_sqr * b_sqr; // Функция координат точки (x+1/2, y-1)

            while (_y + 1 != 0) // Вторая часть дуги, если не выполняется условие первого цикла, значит выполняется a^2(2y - 1) <= 2b^2(x + 1)
            {
                

                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    return bitmap;
                }

                if (delta < 0) // Переход по вертикали
                {
                    int Dx = _x - x;
                    int Dy = _y - y;
                    int e = 2 * Dy - Dx;
                    float d = -1F * e / (Dy + Dx) / 1.15F;
                    b1 = new SolidBrush(SetColor(Math.Abs(1F / 2 - d)));//насыщенный
                    b2 = new SolidBrush(SetColor(Math.Abs(1F / 2 + d)));//слабый
                    _y--;
                    delta += 4 * a_sqr * (2 * _y + 3);

                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b2, x + _x, y - _y, 1, 1);
                        gGraphics.FillRectangle(b1, x + _x - 1, y - _y, 1, 1);//4
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

                    if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                    {
                        gGraphics.FillRectangle(b1, x + _x - 1, y - _y, 1, 1);
                        gGraphics.FillRectangle(b2, x + _x, y - _y, 1, 1);//4
                    }
                }
            }
            return bitmap;
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
