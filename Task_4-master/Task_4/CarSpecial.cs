using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace Task_4
{
   public class CarSpecial:Car
    {
        private static object locker = new object();
        public void GoSpecial(Main main,Car car)
        {
            int carLenght = 121;
            main.Broken = true;
            int speed = 10;
            for (int i = 0; i < 280; i += speed)
            {
                if (Math.Abs(X-car.X)<6)
                {
                    Thread.Sleep(200);
                    car.Fire = false;
                    main.Broken = true;
                }
                if (433 - X - carLenght > -20 && 433 - X - carLenght < 25)
                {
                    BeforeLine = false;
                }

                if (main.GreenLight)
                {
                    speed = 10;
                    if (BeforeLine && (main.ManTransition != 0))
                    {
                        speed = 0;
                    }
                }

                if (!main.GreenLight)
                {
                    if (BeforeLine)
                    {
                        speed = 0;
                    }
                }
                lock (locker)
                {
                    X += speed;
                    main.DrawAll();
                }
            }

            main.CarTransition++;

            for (int i = 0; i < 394 + carLenght; i += 10)
            {
                if (Math.Abs(X - car.X) < 6)
                {
                    Thread.Sleep(200);
                    car.Fire = false;
                    main.Broken = false;
                }
                lock (locker)
                {
                    X += 10;
                    main.DrawAll();
                }
            }
            main.CarTransition--;

            for (int i = 0; i < 1017 + carLenght - 394; i +=10)
            {
                if (Math.Abs(X - car.X) < 6)
                {
                    Thread.Sleep(200);
                    car.Fire = false;
                    main.Broken = false;
                }
                lock (locker)
                {
                    X += 10;
                    main.DrawAll();
                }
            }
            main.Cars.Remove(this);
        }
    }
}
