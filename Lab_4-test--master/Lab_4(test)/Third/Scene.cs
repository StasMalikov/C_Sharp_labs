using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_4_test_
{
   public class Scene
    {
        public List<IModel> models = new List<IModel>();
        public Bitmap DrawAll(Screen scr, Camera cam) 
        {
            Bitmap bmp = new Bitmap(scr.Size.Width,scr.Size.Height);
            Graphics g = Graphics.FromImage(bmp);
            List<PolyLine3D> lines = new List<PolyLine3D>();
            foreach(IModel m in models)
            {
                foreach(PolyLine3D pl in m.GetLines())
                {
                    List<Vector3> vertices = new List<Vector3>();
                    foreach (Vector3 v in pl.Vertices)
                        vertices.Add(cam.Convert(v));
                    lines.Add(new PolyLine3D(vertices,false,pl.color));
                }
            }

            foreach(PolyLine3D pl in lines)
            {
                List<Point> points = new List<Point>();
                foreach (Vector3 v in pl.Vertices)
                    points.Add(scr.Convert(v));
                g.DrawLines( new Pen(pl.color), points.ToArray());
            }
            g.Dispose();
            return bmp;
        }
    }
}
