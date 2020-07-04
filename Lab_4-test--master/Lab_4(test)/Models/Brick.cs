using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_4_test_
{
    public class Brick : IModel
    {
        public Vector3 LTF { get; set; }
        public Vector3 RBN { get; set; }
        public Brick(Vector3 v1, Vector3 v2)
        {
            LTF = v1;
            RBN = v2;
        }
        public List<PolyLine3D> GetLines()
        {
            List<PolyLine3D> answer = new List<PolyLine3D>();
            answer.Add(new PolyLine3D(new List<Vector3>()
            {
                new Vector3(LTF.X,LTF.Y,LTF.Z),new Vector3(RBN.X,LTF.Y,LTF.Z),
                new Vector3(RBN.X,LTF.Y,RBN.Z),new Vector3(LTF.X,LTF.Y,RBN.Z)
            },true,Color.Black));
            answer.Add(new PolyLine3D(new List<Vector3>()
            {
                new Vector3(LTF.X,RBN.Y,LTF.Z),new Vector3(RBN.X,RBN.Y,LTF.Z),
                new Vector3(RBN.X,RBN.Y,RBN.Z),new Vector3(LTF.X,RBN.Y,RBN.Z)
            }, true, Color.Black));

            return answer;
        }
    }
}
