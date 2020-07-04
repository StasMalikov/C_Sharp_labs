using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_test_
{
    public struct Matrix4
    {
        private float[,] values;
        public Matrix4(float[,] v)
        {
            values = new float[4, 4];
            for (int i = 0; i <4; i++)
                for (int j = 0; j < 4; j++)
                    values[i, j] = v[i, j];
        }
        public float this[int i, int j]
        {
            get { return values[i, j]; }
            set { values[i, j] = value; }
        }
        public static Matrix4 Zero()
        {
            float[,] m = new float[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    m[i, j] = 0;

            return new Matrix4(m);  
        }
        public static Matrix4 One()
        {
            float[,] m = new float[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    m[i, j] = (i==j)?1:0;

            return new Matrix4(m);
        }
        public static Vector4 operator *(Matrix4 n,Vector4 v)
        {
            Vector4 r = new Vector4(0,0,0,0);
            for (int i = 0; i < 4; i++)
            {
                r[i] = 0;
                for (int j = 0; j < 4; j++)
                {
                    r[i] += n[i, j] * v[j];
                }
            }
            return r;  
        }
        public static Matrix4 operator *(Matrix4 n1, Matrix4 n2)
        {
            Matrix4 m = Zero();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        m[i, j] += n1[i, k] * n2[k,j];
                    }
                }
            }
            return m;
        }
        public static Matrix4 Translate(int dx,int dy, int dz)
        {
            Matrix4 m = One();
            m[0, 3] = dx;
            m[1, 3] = dy;
            m[2, 3] = dz;
            return m;
        }
        public static Matrix4 Rotate(int xyz, float a)
        {
            Matrix4 m = Matrix4.One();
            int r1 = (xyz + 1) % 3;
            int r2 = (xyz + 2) % 3;
            m[r1, r1] = (float)Math.Cos(a);
            m[r1, r2] = (float)-Math.Sin(a);
            m[r2, r1] = (float)Math.Sin(a);
            m[r2, r2] = (float)Math.Cos(a);
            return m;
        }
    }
}
