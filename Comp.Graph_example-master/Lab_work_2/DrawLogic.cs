using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_work_2
{
    class DrawLogic
    {
        //создать тут методы для  рисованиия 
        public static void DrawHorizontalLine(Bitmap bitmap,Color color,int x,int y,int w) //рисует горизонтальную  линию
        {
            //bitmap.GetPixel
            for (int i = 0; i < w; i++)
            {
                bitmap.SetPixel(x + i, y, color);
            }
            //Graphics g = new Graphics();
        }

        public static void DrawVerticalLine(Bitmap bitmap, Color color, int x, int y, int h)
        {
            for (int i = 0; i < h; i++)
            {
                bitmap.SetPixel(x, y + i, color);
            }
        }

        public static void DrawTransverseLine(Bitmap bitmap, Color color, int x1, int y1, int x2,int y2)
        {
            if (x1 > x2)
            {
                int tmp;
                tmp = x1;
                x1 = x2;
                x2 = tmp;
                tmp = y1;
                y1 = y2;
                y2 = tmp;
            }
            

            int divx = x2 - x1;
            double divy = y2 - y1;
            double delta = divy / divx;


            for (int i = 0; i <= divx; i++)
            {
                bitmap.SetPixel(x1 + i, (int)(y1 + i * delta), color);
            }
        }
    }
}
