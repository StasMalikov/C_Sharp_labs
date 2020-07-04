using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_4_test_
{
   public class Axes:IModel
    {
        public List<PolyLine3D> GetLines()
        {
            List<PolyLine3D> answer = new List<PolyLine3D>();

                    answer.Add(new PolyLine3D(new List<Vector3>()
                    {
                      new Vector3(0,0,0),new Vector3(20,0,0)
                    }, true, Color.Red));

            answer.Add(new PolyLine3D(new List<Vector3>()
                    {
                      new Vector3(0,0,0),new Vector3(0,20,0)
                    }, true, Color.Green));

            answer.Add(new PolyLine3D(new List<Vector3>()
                    {
                      new Vector3(0,0,0),new Vector3(0,0,20)
                    }, true, Color.Blue));


            return answer;
        }
    }
}
