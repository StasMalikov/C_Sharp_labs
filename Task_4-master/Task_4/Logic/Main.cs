using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Task_4
{
    public class Main
    {
        public Image basePic = Image.FromFile(@"BasePicture.bmp");
        public  Image img_Special = Image.FromFile(@"car2.png");
        public  Image img = Image.FromFile(@"car.png");
        public  Image imgFire = Image.FromFile(@"carFire.png");
        public  Image man1 = Image.FromFile(@"man1.png");
        public List<Car> Cars = new List<Car>();
        public List<Man> Mans = new List<Man>();
        public int ManTransition;
        public int CarTransition;
        public bool GreenLight;
        public bool Broken = false;
        private TimerCallback _timeback;
        private Timer _timer;
        private Graphics G;
        Rectangle _rect;
        private static object locker = new object();
        public Main(Graphics g,Rectangle r)
        {
            G = g;
            _rect = r;
            _timeback = new TimerCallback(ChangeLight);
            _timer = new Timer(_timeback, null, 0, 20000);
            GreenLight = false;
        }
        public void DrawAll()
        {
            lock (locker)
            {
                Bitmap bmp = new Bitmap(_rect.Width,_rect.Height);
                Graphics gg = Graphics.FromImage(bmp);
            
                gg.DrawImage(basePic, 0, 0);
                if (GreenLight)
                {
                    gg.FillEllipse(Brushes.DarkRed, 337, 78, 20, 17);
                    gg.FillEllipse(Brushes.LightGreen, 337, 98, 20, 17);
                }
                else
                {
                    gg.FillEllipse(Brushes.Red, 337, 78, 20, 17);
                    gg.FillEllipse(Brushes.DarkGreen, 337, 98, 20, 17);
                }
                foreach (Car tmp in Cars)
                {
                    if (tmp is CarSpecial)
                    {
                        gg.DrawImage(img_Special, tmp.X, tmp.Y - 150);
                    }
                    else
                        if (tmp.Fire)
                    {
                        gg.DrawImage(imgFire, tmp.X, tmp.Y);
                    }
                    else
                    {
                        gg.DrawImage(img, tmp.X, tmp.Y);
                    }
                }
                foreach (Man tmp in Mans)
                {
                    gg.DrawImage(man1, tmp.X, tmp.Y);
                }
                G.DrawImage(bmp, 0, 0);
                gg.Dispose();
                bmp.Dispose();
            }
        }
        public void ChangeLight(object state)
        {
            GreenLight = !GreenLight;
        }
    }
}
