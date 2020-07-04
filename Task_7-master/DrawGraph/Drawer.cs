using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Model;

namespace DrawGraph
{
    public class Drawer
    {
        List<Candle> _candles;
        Size _size;
        public Drawer(List<Candle> list, double width,double height)
        {
            _candles = list;
            _size =new Size((int)width,(int)height);
        }

        public Bitmap Draw()
        {
            Bitmap bmp = new Bitmap(_size.Width, _size.Height);
            Graphics g = Graphics.FromImage(bmp);
            bmp = DrawAxes(bmp);
            for (int i = 0; i < 50; i++)
            {
                bmp = DrawCandle(bmp, _candles[i], i);
            }
            return bmp;
        }

        public Bitmap DrawCandle(Bitmap bmp, Candle cndl,int place)
        {
            Graphics g = Graphics.FromImage(bmp);
            if (cndl.Close> cndl.Open) //green
            {
                g.FillEllipse(Brushes.Green, 10 * place, (float)cndl.Close, 8, (float)(cndl.Close - cndl.Open));
                g.DrawLine(Pens.Black, 10 * place+4, (float)cndl.Close, 10 * place + 4,(float)cndl.High);
                g.DrawLine(Pens.Black, 10 * place + 4, (float)(cndl.Close - cndl.Open), 10 * place + 4, (float)cndl.Low);
            }
            else if(cndl.Close > cndl.Open)//red
            {
                g.FillEllipse(Brushes.Red, 10 * place, (float)cndl.Open, 8, (float)(-cndl.Close + cndl.Open));
                g.DrawLine(Pens.Black, 10 * place + 4, (float)cndl.Open, 10 * place + 4, (float)cndl.High);
                g.DrawLine(Pens.Black, 10 * place + 4, (float)(-cndl.Close + cndl.Open), 10 * place + 4, (float)cndl.Low);
            }
            else if(cndl.Close == cndl.Open)//neitral
            {
                g.DrawLine(Pens.Black, 10 * place,(float)cndl.Open, 10 * place+8, (float)cndl.Open);
                g.DrawLine(Pens.Black, 10 * place + 4, (float)cndl.Open, 10 * place + 4, (float)cndl.High);
                g.DrawLine(Pens.Black, 10 * place + 4, (float) cndl.Open, 10 * place + 4, (float)cndl.Low);
            }

            return bmp;
        }

        public Bitmap DrawAxes(Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(Pens.Black, 0, bmp.Height / 2, bmp.Width, bmp.Height/2);
            g.DrawLine(Pens.Black,10,0,10,bmp.Height);
            return bmp;
        }
    }
}
