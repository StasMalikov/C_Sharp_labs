using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Lab_4_test_
{
   public struct Vector4
    {
        private float[] coordinates;
        public Vector4(Vector3 v):this(v.X,v.Y,v.Z)
        {
        }
        public Vector4(float x, float y, float z,float w=1)
        {
            coordinates = new float[4];
            coordinates[0] = x;
            coordinates[1] = y;
            coordinates[2] = z;
            coordinates[3] = w;
        }
        public float X
        {
            get { return coordinates[0]; }
            set { coordinates[0] = value; }
        }
        public float Y
        {
            get { return coordinates[1]; }
            set { coordinates[1] = value; }
        }
        public float Z
        {
            get { return coordinates[2]; }
            set { coordinates[2] = value; }
        }
        public float W
        {
            get { return coordinates[3]; }
            set { coordinates[3] = value; }
        }
        public float this[int i]
        {
            get { return coordinates[i]; }
            set { coordinates[i] = value; }
        }
        public Vector4 Normalized
        {
            get
            {
                return (W == 0) ?
                    new Vector4(X, Y, Z, W) :
                    new Vector4(X / W, Y / W, Z / W, 1);
            }
        }
        //public Vector4 operator *(Matrix4 n, Vector4 v)
        //{
        //    Vector4 r = new Vector4();
        //    for (int i = 0; i < 4; i++)
        //    {
        //        r[i] = 0;
        //        for (int j = 0; j < 4; j++)
        //        {
        //            r[i] += n[i, j] * v[j];
        //        }
        //    }
        //    return r;
        //}
    }
}
