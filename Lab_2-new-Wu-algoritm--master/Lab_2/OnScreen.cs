namespace Lab_2
{
    public class OnScreen
    {
        int baseX;
        int baseY;
        private int ScreenX;
        private int ScreenY;
        private int ScreenHeight;
        private int ScreenWeight;
        private int x;
        private int y;
        private int Xr;
        private int Yr;
        int HeightR;
        int WeightR;

        public int I(int x)
        {
            return baseX+ ((x - Xr) * ScreenWeight) / WeightR;
        }
        public int J(int y)
        {
            return baseY + ((Yr-y) * ScreenHeight) / HeightR;
        }

        public void Draw()
        {

        }
    }
}
