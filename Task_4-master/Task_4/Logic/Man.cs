using System.Threading;
using System.Drawing;

namespace Task_4
{
    public class Man
    {
        public bool BeforeLine;
        public int X { get; set; }
        public int Y { get; set; }
        private static object locker = new object();
        public Man()
        {
            X = 531;
            Y = 689;
        }
        public void Go(Main main)
        {
            int speed = 2;
            for (int i = 0; i < 111; i += speed)
            {
                if (578 - Y> -2 && 578 - Y < 15)
                    BeforeLine = true;

                if (!main.GreenLight)
                {
                    speed = 4;
                    if (BeforeLine&&!(main.CarTransition==0))
                    {
                        speed = 0;
                    }
                }

                if (main.GreenLight)
                {
                    if (BeforeLine)
                    {
                        speed = 0;
                    }
                }
                    Y -= speed;
                    main.DrawAll();
            }

            main.ManTransition++;
            speed = 6;
            for (int i = 0; i < 276; i += speed)
            {
                if(i==120)
                {
                    NewMan(main);
                }
                    Y -= speed;
                    main.DrawAll();
            }

            main.ManTransition--;
            for (int i = 0; i < 301; i += 3)
            {
                    Y -= 3;
                    main.DrawAll();
            }
            main.Mans.Remove(this);
        }
        public static void NewMan(Main main)
        {
            lock (locker)
            {
                Thread myThread2 = new Thread(() =>
                {
                    Man myMan = new Man();
                    main.Mans.Add(myMan);
                    myMan.Go(main);
                });
                myThread2.Start();
            }
        }
    }
}
