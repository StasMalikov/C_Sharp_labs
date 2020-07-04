using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_4_test_
{
   public class PolyLine3D
    {
        private List<Vector3> vertices;
        public Color color;
        public PolyLine3D(IList<Vector3> v, bool closed,Color _color)
        {
            color = _color;
            vertices = new List<Vector3>(v);
            if (closed) 
                vertices.Add(v[0]);
        }
        public List<Vector3> Vertices
        {
            get { return vertices; }
        }
    }
}
