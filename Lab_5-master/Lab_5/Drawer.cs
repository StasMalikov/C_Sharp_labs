using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Lab_5
{
    public class Drawer
    {
        public Graphics G;
        Rectangle _rect;
        private static object locker = new object();
        public Drawer(Graphics g, Rectangle rectangle)
        {
            _rect = rectangle;
            G = g;
        }

        public void DrawPic( Locomotive lcmt)
        {
                Bitmap bmp = new Bitmap(_rect.Width, _rect.Height);
                Graphics gg = Graphics.FromImage(bmp);
                gg.Clear(Color.White);
            if (lcmt.Wheels.Count > 0)
            {
                gg.FillRectangle(Brushes.Black, lcmt.Wheels[0].Center.X + lcmt.Wheels[0].Radius + 130,
                    lcmt.Wheels[0].Center.Y + lcmt.Wheels[0].Radius - 190, 100, 50);//основание внешней силы
                float lever_arm = lcmt.StartAngle + 20;
                for (int i = 0; i < lcmt.Wheels.Count; i++)
                {
                    if (lcmt.Wheels.Count - 1 >= i)
                    {
                        gg.FillEllipse(Brushes.Black, lcmt.Wheels[i].Center.X - 7 - lcmt.Wheels[i].Radius / 2,  //шина
                            lcmt.Wheels[i].Center.Y - 7 - lcmt.Wheels[i].Radius / 2, lcmt.Wheels[i].Radius + 14, lcmt.Wheels[i].Radius + 14);

                        gg.FillEllipse(Brushes.White, lcmt.Wheels[i].Center.X - lcmt.Wheels[i].Radius / 2,  //фон колеса
                            lcmt.Wheels[i].Center.Y - lcmt.Wheels[i].Radius / 2, lcmt.Wheels[i].Radius, lcmt.Wheels[i].Radius);

                        for (int j = (int)lcmt.StartAngle; j < (int)lcmt.StartAngle + 360; j += 45) //колёса /lcmt.StartAngle переменная меняется при движении 
                        {
                            gg.DrawLine(new Pen(Color.Black, 5), lcmt.Wheels[i].Center.X,
                                lcmt.Wheels[i].Center.Y,
                            lcmt.Wheels[i].Center.X + lcmt.Wheels[i].Radius / 2 * (float)Math.Cos(j * Math.PI / 180),
                            lcmt.Wheels[i].Center.Y + lcmt.Wheels[i].Radius / 2 * (float)Math.Sin(j * Math.PI / 180));
                        }

                        //рисование рычага
                        gg.DrawLine(new Pen(Color.Red, 8), lcmt.Wheels[i].Center.X, lcmt.Wheels[i].Center.Y,
                        lcmt.Wheels[i].Center.X + (float)(lcmt.Wheels[i].Radius / 2.5) * (float)Math.Cos(lever_arm * Math.PI / 180),
                        lcmt.Wheels[i].Center.Y + (float)(lcmt.Wheels[i].Radius / 2.5) * (float)Math.Sin(lever_arm * Math.PI / 180));
                    }

                    //балка, скрепляющая все колёса
                    gg.DrawLine(new Pen(Color.Green, 6),
                    lcmt.Wheels[0].Center.X + (float)(lcmt.Wheels[0].Radius / 2.5) * (float)Math.Cos(lever_arm * Math.PI / 180),
                    lcmt.Wheels[0].Center.Y + (float)(lcmt.Wheels[0].Radius / 2.5) * (float)Math.Sin(lever_arm * Math.PI / 180),
                    lcmt.Wheels[lcmt.Wheels.Count - 1].Center.X + (float)(lcmt.Wheels[lcmt.Wheels.Count - 1].Radius / 2.5) * (float)Math.Cos(lever_arm * Math.PI / 180),
                    lcmt.Wheels[lcmt.Wheels.Count - 1].Center.Y + (float)(lcmt.Wheels[lcmt.Wheels.Count - 1].Radius / 2.5) * (float)Math.Sin(lever_arm * Math.PI / 180));
                }
                //крепеление рычага к колесу
                for (int i = 0; i < lcmt.Wheels.Count; i++)
                {
                    if (lcmt.Wheels.Count - 1 >= i)
                    {
                        if (lcmt.Wheels[i].Special)
                        {
                            int delta = (int)Math.Sqrt(Math.Pow(lcmt.Wheels[i].Radius-
                               (float)(lcmt.Wheels[i].Radius / 2.5) * (float)Math.Cos(lever_arm * Math.PI / 180),2)+
                                Math.Pow((lcmt.Wheels[i].Radius / 2.5) * Math.Sin(lever_arm * Math.PI / 180), 2));
                            gg.DrawLine(new Pen(Color.Blue, 6),
                                lcmt.Wheels[i].Center.X + (float)(lcmt.Wheels[i].Radius / 2.5) * (float)Math.Cos(lever_arm * Math.PI / 180),
                                lcmt.Wheels[i].Center.Y + (float)(lcmt.Wheels[i].Radius / 2.5) * (float)Math.Sin(lever_arm * Math.PI / 180),
                                lcmt.Wheels[0].Center.X + lcmt.Wheels[0].Radius + 130 + 50-delta,
                                lcmt.Wheels[0].Center.Y + lcmt.Wheels[0].Radius - 190 + 25);

                            gg.DrawLine(new Pen(Color.Blue, 6), lcmt.Wheels[0].Center.X + lcmt.Wheels[0].Radius + 130 + 50 - delta,
                                lcmt.Wheels[0].Center.Y + lcmt.Wheels[0].Radius - 190 + 25,
                                lcmt.Wheels[0].Center.X + lcmt.Wheels[0].Radius + 130+50,
                                lcmt.Wheels[0].Center.Y + lcmt.Wheels[0].Radius - 190+25
                                );
                        }
                    }
                }
            }
            lock (locker)
            {
                G.DrawImage(bmp, 0, 0);
            }
                gg.Dispose();
                bmp.Dispose();
           
        }
    } }
    //} for (int i = 0; i<lcmt.Wheels.Count; i++)
    //            {
    //                if (lcmt.Wheels[i].Special)
    //                {
    //                    gg.DrawLine(new Pen(Color.Blue, 6),
    //                        lcmt.Wheels[i].Center.X + (float) (lcmt.Wheels[i].Radius / 2.5) * (float) Math.Cos(lever_arm* Math.PI / 180),
    //                        lcmt.Wheels[i].Center.Y + (float) (lcmt.Wheels[i].Radius / 2.5) * (float) Math.Sin(lever_arm* Math.PI / 180),
    //                        lcmt.Wheels[1].Center.X + lcmt.Wheels[1].Radius + 130 + 50,
    //                        lcmt.Wheels[1].Center.Y + lcmt.Wheels[1].Radius - 190 + 25);
    //                }
    //            
