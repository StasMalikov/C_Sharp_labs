using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    public struct Vector2
    {
        private float x, y;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { x = value; }
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float Length
        {
            get { return (float)Math.Sqrt(x * x + y * y); }
        }

        public Vector2 Normalized
        {
            get
            {
                return (Length < 1e-15) ?
                    new Vector2(x, y) :
                    new Vector2(x / Length, y / Length);
            }
        }

        public static Vector2 Zero
        {
            get { return new Vector2(0, 0); }
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }
        //public static Vector2 operator +(Vector2 v1, Vector2 v2)
        //{
        //    return new Vector2(v1.x + v2.x, v1.y + v2.y);
        //}
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }
        public static Vector2 operator *(Vector2 v1, float n)
        {
            return new Vector2(v1.x * n, v1.y * n);
        }

        public static Vector2 operator *(float n, Vector2 v1)
        {
            return new Vector2(v1.x * n, v1.y * n);
        }
    }
}
