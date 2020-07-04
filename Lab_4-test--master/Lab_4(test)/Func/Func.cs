using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab_4_test_.Func
{
    internal class Func : IModel
    {
        public float StartX { get; set; }
        public float EndX { get; set; }
        public float StartY { get; set; }
        public float EndY { get; set; }

        public float N1 { get; set; }
        public float N2 { get; set; }
        protected float deltaX;
        protected float deltaY;
        public IFunc function { get; set; }
        public Func(float Sx, float Ex, float Sy, float Ey, float n1, float n2)
        {
            StartX = Sx;
            EndX = Ex;
            StartY = Sy;
            EndY = Ey;
            N1 = n1;
            N2 = n2;
            deltaX = (Ex - Sx) / n1;
            deltaY = Math.Abs((Sy - Ey) / n2);
        }
        public List<PolyLine3D> GetLines()
        {
            List<PolyLine3D> answer = new List<PolyLine3D>();
            if (function == null)
            {
                return answer;
            }

            for (float y = StartY; y < EndY; y += deltaY)
            {
                for (float x = StartX; x < EndX - deltaX; x += deltaX)
                {
                    if (function.FuncTry(x, y) && function.FuncTry(x + deltaX, y) &&
                        function.FuncTry(x, y + deltaY) && function.FuncTry(x + deltaX, y + deltaY))
                    {
                        answer.Add(new PolyLine3D(new List<Vector3>()
                    {
                      new Vector3(x,y,function.F(x,y)),new Vector3(x+deltaX,y,function.F(x+deltaX,y)),
                      new Vector3(x,y+deltaY,function.F(x,y+deltaY)),new Vector3(x+deltaX,y+deltaY,function.F(x+deltaX,y+deltaY))
                    }, true, Color.Black));
                    }
                }
                if (function.FuncTry(StartX, y) && function.FuncTry(StartX + deltaX, y) &&
                        function.FuncTry(StartX, y + deltaY) && function.FuncTry(StartX + deltaX, y + deltaY))
                {
                    answer.Add(new PolyLine3D(new List<Vector3>()
                    {
                      new Vector3(StartX,y,function.F(StartX,y)),new Vector3(StartX,y+deltaY,function.F(StartX,y+deltaY)),
                      new Vector3(StartX,y+deltaY/2,function.F(StartX,y+deltaY/2)) }, true, Color.Black));

                    answer.Add(new PolyLine3D(new List<Vector3>()
                    {
                      new Vector3(EndX,y,function.F(EndX,y)),new Vector3(EndX,y+deltaY,function.F(EndX,y+deltaY)),
                      new Vector3(EndX,y+deltaY/2,function.F(EndX,y+deltaY/2)) }, true, Color.Black));
                }

            }
            return answer;
        }
    }
}
