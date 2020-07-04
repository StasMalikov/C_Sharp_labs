using System;

namespace Task_3_restructered_
{
    public class Vector2
    {
        private float x, y;
        public float X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public float Y
        { get { return y; } set { y = value; } }
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public float Length { get { return (float)Math.Sqrt(x * x + y * y); } }
        public Vector2 Normalized { get { return (Length < 1e-15) ? new Vector2(x, y) : new Vector2(x / Length, y / Length); } }
        public static Vector2 Zero { get { return new Vector2(0, 0); } }
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator *(Vector2 v1, float n)
        {
            return new Vector2(v1.X * n, v1.Y * n);
        }

        public static Vector2 operator *(float n, Vector2 v1)
        {
            return new Vector2(v1.X * n, v1.Y * n);
        }
    }
}
