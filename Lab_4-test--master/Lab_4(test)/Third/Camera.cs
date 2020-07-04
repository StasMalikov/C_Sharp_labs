using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_test_
{
   public class Camera
    {
        public Matrix4 View { get; set; }
        public Matrix4 Projection { get; set; }
        public Camera()
        {
            View = Matrix4.One();
            Projection = Matrix4.One();
        }
        public Vector3 Convert(Vector3 v)
        {
            Vector4 r = Projection * View * new Vector4(v);
            return new Vector3(r.Normalized);
        }
    }
}
