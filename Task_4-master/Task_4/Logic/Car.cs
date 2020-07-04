using System.Threading;
using System.Drawing;
using System;

namespace Task_4
{
    public class Car : IEmergency_Service
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool BeforeLine;
        public bool Fire;
        public delegate void Crash(Main main, Car car);
        public event Crash CrashHappen;
        private static object locker = new object();
        public Car()
        {
            X = 10;
            Y = 450;
            BeforeLine = false;
            CrashHappen += Troubleshooting;
        }
        public virtual void Go(Main main)
        {
            int carLenght = 152;
            Random rnd = new Random();
            int speed = 10;
            for (int i = 0; i < 280; i += speed)
            {
                if (433 - X- carLenght > -7 && 433 - X- carLenght < 15)
                {
                    BeforeLine = true;
                }

                if (main.GreenLight)
                {
                    speed = 10;
                    if (BeforeLine && !(main.ManTransition == 0))
                    {
                        speed = 0;
                    }
                }

                if (!main.GreenLight)
                {
                    if (BeforeLine||main.Broken)
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

            for (int i = 0; i < 394 + carLenght; i += speed)
            {
                if (main.Broken)
                    speed = 0;
                else
                    speed = 10;
                lock (locker)
                {
                    X += speed;
                    main.DrawAll();
                }
            }
            NewCar(main);
            main.CarTransition--;
            if (rnd.Next(2) == 1) //симулятор аварии
                CrashHappen(main, this);

            for (int i = 0; i < 1017 + carLenght - 394; i += speed)
            {
                if (main.Broken)
                    speed = 0;
                else
                    speed = 10;
                lock (locker)
                {
                    X += speed;
                    main.DrawAll();
                }
            }
            main.Cars.Remove(this);
        }
        public static void NewCar(Main main)
        {
            lock (locker)
            {
                Thread myThread = new Thread(() =>
                {
                    Car myCar = new Car();
                    main.Cars.Add(myCar);
                    myCar.Go(main);
                });
                myThread.Start();
            }
        }

        public void Troubleshooting(Main main,Car car)
        {
            car.Fire = true;
            main.Broken = true;
            NewSpecialCar(main, car);
        }
        public void NewSpecialCar(Main main, Car car)
        {
            lock (locker)
            {
                Thread myThread = new Thread(() =>
            {
                CarSpecial myCar = new CarSpecial();
                main.Cars.Add(myCar);
                myCar.GoSpecial(main, car);
            });
                myThread.Start();
            }
        }
    }
}
