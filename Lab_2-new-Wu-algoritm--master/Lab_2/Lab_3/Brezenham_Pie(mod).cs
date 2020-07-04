using System;
using System.Drawing;
using Lab_2;

namespace Lab_3
{
    public class Brezenham_Pie
    {
        private Color color = Color.Black;
        private int _height;
        private int _weight;

        public Brezenham_Pie(int weight, int height)//конструктор
        {
            _height = height;
            _weight = weight;
        }

        public void DrawPie(Graphics g,int x, int y, int a, int b, int startAngle, int endAngle, Color color)
        {
            g.Clear(Color.White);
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
                    case 1: { FirstPart(g, x, y, a, b, startAngle, endAngle, true, true); break; }
                    case 2: { SecondPart(g, x, y, a, b, startAngle, endAngle, true, true); break; }
                
                    case 3:  {ThirdPart(g, x, y, a, b, startAngle, endAngle, true, true); break; }
                    case 4: { FourthPart(g, x, y, a, b, startAngle, endAngle, true, true); break;
                }
            }
            }

            if ((startPart == 1) && (endPart == 2))
            {
                FirstPart(g,  x, y, a, b, startAngle, 90,true,false); //1
                SecondPart(g, x, y, a, b, 90, endAngle, false, true);
            }

            if ((startPart == 1) && (endPart == 3))
            {
                ThirdPart(g, x, y, a, b, 180, endAngle, false, true);
                FirstPart(g, x, y, a, b, startAngle, 90, true, false);
                SecondPart( g, x, y, a, b, 90, 180, false, false);              //2
                                                                           ; //1
            }
            if ((startPart == 1) && (endPart == 4))
            {
                FourthPart(g, x, y, a, b, 270, endAngle, false, true);
                ThirdPart(g, x, y, a, b, 180, 270, false, false);
                SecondPart(g, x, y, a, b, 90, 180, false, false);
                FirstPart(g, x, y, a, b, startAngle, 90,true,false);         //1
            }
            if ((startPart == 2) && (endPart == 3))
            {
                ThirdPart(g, x, y, a, b, 180, endAngle, false, true);
                SecondPart(g, x, y, a, b, startAngle, 180,true,false);   //2
            }
            if ((startPart == 2) && (endPart == 4))
            {
                FourthPart(g, x, y, a, b, 270, endAngle, false, true);
                ThirdPart(g, x, y, a, b, 180, 270, false, false);
                SecondPart(g,x, y, a, b, startAngle, 180,true,false);                 //2
            }
            if ((startPart == 3) && (endPart == 4))
            {
                FourthPart(g, x, y, a, b, 270, endAngle, false, true);
                ThirdPart(g,x, y, a, b, startAngle, 270,true,false);                 //3
            }
        }
         
        private void FirstPart(Graphics g, int x, int y, int a, int b, double start, double end, bool pieStart, bool pieEnd)
        {
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
                //bitmap = Line.Bresenham(bitmap, x + _x, y + _y, x, y, color);
               Line.Newline(g, x + _x, y+_y, x, y, color);
            }


            //серединная точка при выборе пикселей
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
                if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                {
                    g.FillRectangle(new SolidBrush(color), x + _x, y + _y, 1, 1);
                    //bitmap.SetPixel(x + _x, y + _y, color);//1
                }
                if ((((_y - end_y) > 0) && ((_y - end_y) < 7)) && (((end_x - _x) > 0) && ((end_x - _x) < 7))) //условие выхода
                {

                    if (pieStart)
                    {
                        int dy = 0;
                        if (start2 != 0)
                            dy = _y;
                        //bitmap = Line.Bresenham(bitmap, x + _x, y + _y, x, y, color);
                       Line.Newline(g, x+_x , y+dy, x, y, color);
                        break;
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
                if (((x + _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                {
                    g.FillRectangle(new SolidBrush(color), x + _x, y + _y, 1, 1);
                    //bitmap.SetPixel(x + _x, y + _y, color);//1
                }

                if ((((_y - end_y) > 0) && ((_y - end_y) < 7)) && (((end_x - _x) > 0) && ((end_x - _x) < 7))) //условие выхода
                {
                    if (pieStart)
                    {
                        int dy = 0;
                        if (start2 != 0)
                            dy = _y;
                        Line.Newline(g, x + _x, y+dy , x, y, color);
                        break;
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
                Line.Newline(g, x + _x, y + dy, x, y, color);
            }

        }

        private void SecondPart(Graphics g, int x, int y, int a, int b, double start, double end, bool pieStart, bool pieEnd)
        {
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
               // bitmap = Line.Bresenham(bitmap, x - _x, y + _y, x, y, color);
                 Line.Newline(g, x - _x, y + _y, x, y, color);
            }

            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
                if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                {
                    g.FillRectangle(new SolidBrush(color), x - _x, y + _y, 1, 1);
                    //bitmap.SetPixel(x - _x, y + _y, color);//2
                }

                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    if (pieEnd)
                    {
                        int dy = 0;
                        if (end2 != 180)
                            dy = _y;
                        Line.Newline(g, x - _x, y + dy, x, y, color);
                    }

                    break;
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
                if (((x - _x) >= 0) && ((y + _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                {
                    g.FillRectangle(new SolidBrush(color), x - _x, y + _y, 1, 1);
                    //bitmap.SetPixel(x - _x, y + _y, color);//2
                }
                //(((_y-end_y)>0) &&((_y - end_y)<5))  &&  (((end_x-_x)>0)&&((end_x - _x)<5))
                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    if (pieEnd)
                    {
                        int dy = 0;
                        if (end2 != 180)
                            dy = _y;
                        Line.Newline(g, x - _x, y + dy, x, y, color);
                    }

                    break;
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
                Line.Newline(g, x - _x, y + dy, x, y, color);
            }
        }
        private void ThirdPart(Graphics g, int x, int y, int a, int b, double start, double end, bool pieStart, bool pieEnd)
        {
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

                Line.Newline(g, x - _x, y - _y, x, y, color);
            }

            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
                if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                {
                    g.FillRectangle(new SolidBrush(color), x - _x, y - _y, 1, 1);
                   // bitmap.SetPixel(x - _x, y - _y, color);//3
                }
                if ((((_y - end_y) > 0) && ((_y - end_y) < 7)) && (((end_x - _x) > 0) && ((end_x - _x) < 7))) //условие выхода
                {
                    if (pieStart)
                    {
                        int dy = 0;
                        if (start2 != 180)
                            dy = _y;
                        Line.Newline(g, x - _x, y - dy, x, y, color);
                    }
                    break;
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
                if (((x - _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                {
                    g.FillRectangle(new SolidBrush(color), x - _x, y - _y, 1, 1);
                    //bitmap.SetPixel(x - _x, y - _y, color);//3
                }

                if ((((_y - end_y) > 0) && ((_y - end_y) < 7)) && (((end_x - _x) > 0) && ((end_x - _x) < 7))) //условие выхода
                {
                    if (pieStart)
                    {
                        int dy = 0;
                        if (start2 != 180)
                            dy = _y;
                         Line.Newline(g, x - _x, y - dy, x, y, color);
                    }
                    break;
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
                 Line.Newline(g, x - _x, y - dy, x, y, color);
            }
        }
        private void FourthPart(Graphics g, int x, int y, int a, int b, double start, double end, bool pieStart, bool pieEnd)
        {
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
                //bitmap = Line.Bresenham(bitmap, x + _x, y - _y, x, y, color);
                Line.Newline(g, x + _x, y - _y, x, y, color);
            }

            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) // Первая часть дуги
            {
                // рисуем
                if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                {
                    g.FillRectangle(new SolidBrush(color), x + _x, y - _y, 1, 1);
                    //bitmap.SetPixel(x + _x, y - _y, color);//4
                }

                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    if (pieEnd)
                    {
                        int dy = 0;
                        if (end2 != 360)
                            dy = _y;
                       Line.Newline(g, x + _x, y - dy, x, y, color);
                    }

                    break;
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
                if (((x + _x) >= 0) && ((y - _y) >= 0) && ((x + _x) < _weight) && ((y + _y) < _height))
                {
                    g.FillRectangle(new SolidBrush(color), x + _x, y - _y, 1, 1);
                    //bitmap.SetPixel(x + _x, y - _y, color);//4
                }

                if ((((_y - end_y) > 0) && ((_y - end_y) < breakPoint)) && (((end_x - _x) > 0) && ((end_x - _x) < breakPoint))) //условие выхода
                {
                    if (pieEnd)
                    {
                        int dy = 0;
                        if (end2 != 360)
                            dy = _y;
                        Line.Newline(g, x + _x, y - dy, x, y, color);
                    }

                    break;
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
                 Line.Newline(g, x + _x, y - dy, x, y, color);
            }
        }
    }
}

