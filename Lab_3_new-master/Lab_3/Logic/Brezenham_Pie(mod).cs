using System;
using System.Drawing;
using Lab_2;

namespace Lab_3
{
    public class Brezenham_Pie_mod
    {
        private Color color = Color.Black;
        public int _height { get; set; }
        public int _weight { get; set; }
        public Bitmap gBitmap { get; set; }
        private Graphics g { get; set; }

        public Bitmap DrawPie(int x, int y, int a, int b, int startAngle, int endAngle,
                                               out Point Start,out Point End ,Color color, int h, int w)
        {

            b = a;// теперь мы работаем с кругом
            _height = h;
            _weight = w;
            gBitmap = new Bitmap(_weight, _height);
            g = Graphics.FromImage(gBitmap);
            g.Clear(Color.White);

            Point badPoint=new Point();
            Point good = new Point();
            good.X = 0;
            good.Y = 0;
            Start = good;
            End = good;
            g.Clear(Color.White);
            int startPart = 0;
            endAngle += startAngle;
            int endPart = 0;

            if (startAngle % 360 == 0)
            {
                startAngle = 0;
            }
            else
            {
                startAngle = startAngle % 360;
            }

            if (endAngle % 360 == 0)
            {

                endAngle = 360;
            }
            else
            {
                endAngle = endAngle % 360;
            }
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
                    case 1: return Line.Newline(FirstPart(gBitmap, x, y, a, b, startAngle, endAngle, true, true, out Start, out End),
                                    Start.X, Start.Y, End.X, End.Y, color, _height, _weight);

                    case 2: return Line.Newline(SecondPart(gBitmap, x, y, a, b, startAngle, endAngle, true, true, out Start, out End),
                                    Start.X, Start.Y, End.X, End.Y, color, _height, _weight);

                    case 3:  return Line.Newline(ThirdPart(gBitmap, x, y, a, b, startAngle, endAngle, true, true, out Start, out End),
                                    Start.X, Start.Y, End.X, End.Y, color, _height, _weight);

                    case 4: return Line.Newline(FourthPart(gBitmap, x, y, a, b, startAngle, endAngle, true, true, out Start, out End),
                                    Start.X, Start.Y, End.X, End.Y, color, _height, _weight);
                }
            }

            if ((startPart == 1) && (endPart == 2))
            {
                gBitmap= FirstPart(gBitmap,  x, y, a, b, startAngle, 90,true,false, out Start, out badPoint); //1
                gBitmap= SecondPart(gBitmap, x, y, a, b, 90, endAngle, false, true, out badPoint, out End);
                return Line.Newline(gBitmap, Start.X, Start.Y, End.X, End.Y, color, _height, _weight);
            }

            if ((startPart == 1) && (endPart == 3))
            {
                gBitmap = ThirdPart(gBitmap, x, y, a, b, 180, endAngle, false, true, out badPoint, out End);
                gBitmap = FirstPart(gBitmap, x, y, a, b, startAngle, 90, true, false, out Start, out badPoint);
                gBitmap = SecondPart(gBitmap, x, y, a, b, 90, 180, false, false, out badPoint, out badPoint);              //2
                return Line.Newline(gBitmap, Start.X, Start.Y, End.X, End.Y, color, _height, _weight);
            }
            if ((startPart == 1) && (endPart == 4))
            {
                gBitmap = FourthPart(gBitmap, x, y, a, b, 270, endAngle, false, true, out badPoint, out End);
                gBitmap = ThirdPart(gBitmap, x, y, a, b, 180, 270, false, false, out badPoint, out badPoint);
                gBitmap = SecondPart(gBitmap, x, y, a, b, 90, 180, false, false, out badPoint, out badPoint);
                gBitmap = FirstPart(gBitmap, x, y, a, b, startAngle, 90,true,false, out Start, out badPoint);
                return Line.Newline(gBitmap, Start.X, Start.Y, End.X, End.Y, color, _height, _weight);
            }
            if ((startPart == 2) && (endPart == 3))
            {
                gBitmap = ThirdPart(gBitmap, x, y, a, b, 180, endAngle, false, true, out badPoint, out End);
                gBitmap = SecondPart(gBitmap, x, y, a, b, startAngle, 180,true,false, out Start, out badPoint);
                return Line.Newline(gBitmap, Start.X, Start.Y, End.X, End.Y, color, _height, _weight);
            }
            if ((startPart == 2) && (endPart == 4))
            {
                gBitmap = FourthPart(gBitmap, x, y, a, b, 270, endAngle, false, true, out badPoint, out End);
                gBitmap = ThirdPart(gBitmap, x, y, a, b, 180, 270, false, false, out badPoint, out badPoint);
                gBitmap = SecondPart(gBitmap, x, y, a, b, startAngle, 180,true,false, out Start, out badPoint);
                return Line.Newline(gBitmap, Start.X, Start.Y, End.X, End.Y, color, _height, _weight);
            }
            if ((startPart == 3) && (endPart == 4))
            {
                gBitmap = FourthPart(gBitmap, x, y, a, b, 270, endAngle, false, true, out badPoint, out End);
                gBitmap = ThirdPart(gBitmap, x, y, a, b, startAngle, 270,true,false, out Start, out badPoint);
                return Line.Newline(gBitmap, Start.X, Start.Y, End.X, End.Y, color, _height, _weight);
            }
            return gBitmap;
        }
         
        private Bitmap FirstPart(Bitmap bitmap, int x, int y, int a, int b, 
            double start, double end, bool pieStart, bool pieEnd,out Point startPoint,out Point endPoint)
        {
            Graphics g = Graphics.FromImage(bitmap);
            
            endPoint = new Point();
            startPoint = new Point();
            double start2 = start;
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
                endPoint.X = x + _x;
                endPoint.Y = y + _y;
                g.DrawEllipse(new Pen(color), x + _x, y + _y, 6, 6);
            }


            //серединная точка при выборе пикселей
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
                if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                {
                    bitmap.SetPixel(x + _x, y + _y, color);//1
                }
                if ((((_y - end_y) > 0) && ((_y - end_y) < 7)) && (((end_x - _x) > 0) && ((end_x - _x) < 7))) //условие выхода
                {

                    if (pieStart)
                    {
                        int dy = 0;
                        if (start2 != 0)
                            dy = _y;
                        startPoint.X = x + _x;
                        startPoint.Y = y + dy;
                        g.DrawEllipse(new Pen(color), x + _x, y + dy, 6, 6);
                    }
                    return bitmap;
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
                if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                {
                    bitmap.SetPixel(x + _x, y + _y, color);//1
                }

                if ((((_y - end_y) > 0) && ((_y - end_y) < 7)) && (((end_x - _x) > 0) && ((end_x - _x) < 7))) //условие выхода
                {
                    if (pieStart)
                    {
                        int dy = 0;
                        if (start2 != 0)
                            dy = _y;
                        startPoint.X = x + _x;
                        startPoint.Y = y + dy;
                        g.DrawEllipse(new Pen(color), x + _x, y + dy, 6, 6);
                    }
                    return bitmap;
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
                startPoint.X = x + _x;
                startPoint.Y = y + dy;
                g.DrawEllipse(new Pen(color), x + _x, y + dy, 6, 6);
            }
            return bitmap;
        }

        private Bitmap SecondPart(Bitmap bitmap, int x, int y, int a, int b, double start, double end, 
                                            bool pieStart, bool pieEnd,out Point startPoint, out Point endPoint)
        {
            Graphics g = Graphics.FromImage(bitmap);

            endPoint = new Point();
            startPoint = new Point();
            double end2 = end;
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
                g.DrawEllipse(new Pen(color), x - _x, y + _y, 6, 6);
                startPoint.X = x - _x;
                startPoint.Y = y + _y;
            }

            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
                if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x - _x) < _weight) && ((y + _y) < _height))
                {
                    g.FillRectangle(new SolidBrush(color), x - _x, y + _y, 1, 1);
                }

                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    if (pieEnd)
                    {
                        int dy = 0;
                        if (end2 != 180)
                            dy = _y;
                        endPoint.X = x - _x;
                        endPoint.Y = y + dy;
                        g.DrawEllipse(new Pen(color), x - _x, y + dy, 6, 6);
                    }

                    return bitmap;
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
                if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x - _x) < _weight) && ((y + _y) < _height))
                {
                    g.FillRectangle(new SolidBrush(color), x - _x, y + _y, 1, 1);
                }
                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    if (pieEnd)
                    {
                        int dy = 0;
                        if (end2 != 180)
                            dy = _y;
                        endPoint.X = x - _x;
                        endPoint.Y = y + dy;
                        g.DrawEllipse(new Pen(color), x - _x, y + dy, 6, 6);
                    }

                    return bitmap;
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
                g.DrawEllipse(new Pen(color), x - _x, y + dy, 6, 6);
                endPoint.X = x - _x;
                endPoint.Y = y + dy;
            }
            return bitmap;
        }
        private Bitmap ThirdPart(Bitmap bitmap, int x, int y, int a, int b, double start, double end,
                                 bool pieStart, bool pieEnd, out Point startPoint, out Point endPoint)
        {
            Graphics g = Graphics.FromImage(bitmap);
            endPoint = new Point();
            startPoint = new Point();
            double start2 = start;
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
                g.DrawEllipse(new Pen(color), x - _x, y - _y, 6, 6);
                endPoint.X = x - _x;
                endPoint.Y = y - _y;
            }

            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
                if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x - _x) < _weight) && ((y - _y) < _height))
                {
                    g.FillRectangle(new SolidBrush(color), x - _x, y - _y, 1, 1);
                }
                if ((((_y - end_y) > 0) && ((_y - end_y) < 7)) && (((end_x - _x) > 0) && ((end_x - _x) < 7))) //условие выхода
                {
                    if (pieStart)
                    {
                        int dy = 0;
                        if (start2 != 180)
                            dy = _y;
                        g.DrawEllipse(new Pen(color), x - _x, y - dy, 6, 6);
                        startPoint.X = x - _x;
                        startPoint.Y = y - dy;
                    }
                    return bitmap;
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
                if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x - _x) < _weight) && ((y - _y) < _height))
                {
                    g.FillRectangle(new SolidBrush(color), x - _x, y - _y, 1, 1);
                }

                if ((((_y - end_y) > 0) && ((_y - end_y) < 7)) && (((end_x - _x) > 0) && ((end_x - _x) < 7))) //условие выхода
                {
                    if (pieStart)
                    {
                        int dy = 0;
                        if (start2 != 180)
                            dy = _y;
                        g.DrawEllipse(new Pen(color), x - _x, y - dy, 6, 6);
                        startPoint.X = x - _x;
                        startPoint.Y = y - dy;
                    }
                    return bitmap;
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
                g.DrawEllipse(new Pen(color), x - _x, y - dy, 6, 6);
                startPoint.X = x - _x;
                startPoint.Y = y - dy;
            }
            return bitmap;
        }
        private Bitmap FourthPart(Bitmap bitmap, int x, int y, int a, int b, double start, double end, 
                         bool pieStart, bool pieEnd, out Point startPoint, out Point endPoint)
        {
            Graphics g = Graphics.FromImage(bitmap);
            endPoint = new Point();
            startPoint = new Point();

            double end2 = end;
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
                g.DrawEllipse(new Pen(color), x + _x, y - _y, 6, 6);
                startPoint.X = x + _x;
                startPoint.Y = y - _y;
            }

            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
                if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y - _y) < _height))
                {
                    g.FillRectangle(new SolidBrush(color), x + _x, y - _y, 1, 1);
                }

                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    if (pieEnd)
                    {
                        int dy = 0;
                        if (end2 != 360)
                            dy = _y;
                        g.DrawEllipse(new Pen(color), x + _x, y - dy, 6, 6);
                        endPoint.X = x + _x;
                        endPoint.Y = y - dy;
                    }

                    return bitmap;
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
                if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y - _y) < _height))
                {
                    g.FillRectangle(new SolidBrush(color), x + _x, y - _y, 1, 1);
                }

                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    if (pieEnd)
                    {
                        int dy = 0;
                        if (end2 != 360)
                            dy = _y;
                        g.DrawEllipse(new Pen(color), x + _x, y - dy, 6, 6);
                        endPoint.X = x + _x;
                        endPoint.Y = y - dy;
                    }

                    return bitmap;
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
                g.DrawEllipse(new Pen(color), x + _x, y - dy, 6, 6);
                endPoint.X = x + _x;
                endPoint.Y = y - dy;
            }
            return bitmap;
        }
    }
}

