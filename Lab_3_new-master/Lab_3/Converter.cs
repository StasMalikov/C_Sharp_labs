using Lab_3.Logic;

namespace Lab_3
{
    public class Converter
    {
        private int Height;
        private int Width;
        private Draw_Data data = new Draw_Data();


        public Converter(int h, int w, Draw_Data d)
        {
            data = d;
            Height = h;
            Width = w;
        }

        public void Refresh(Draw_Data d, int h, int w)
        {
            data = d;
            Height = h;
            Width = w;
        }

        public int II
        {
            get
            {
                return ((data.StartX - data.dx) * data.Wr) / Width;
            }
        }

        public int JJ
        {
            get
            {
                return ((data.dy - data.StartY) * data.Hr) / Height;
            }
        }

        public int Invert_II
        {
            get
            {
                return data.Xr * Width / data.Wr + data.dx;
            }
        }

        public int Invert_JJ
        {
            get
            {
                return -(data.Yr * Height / data.Hr) + data.dy;
            }
        }
    }
}
