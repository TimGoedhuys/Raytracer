using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using static System.Math;

namespace template.Elements
{
    class Ray
    {

        public Vector3 L, colorOutput;
        public float Tca, Thc, t0, t1, d;
        public float tToPoint;
        public Vector3 viewablePoint;

        public Ray(Vector3 start, Vector3 vec, List<Primitives.Sphere> objects, float maxT)
        {

            tToPoint = maxT;
            colorOutput = new Vector3(0, 0, 0);

            foreach (var obj in objects)
            {
                Vector3 pos = obj.Position;
                L = pos - start;
                Tca = Vector3.Dot(L, vec);
                if (Tca < 0) continue;
                d = (float)Sqrt(Vector3.Dot(L, L) - (Tca * Tca));
                if (d > obj.Radius) continue;
                Thc = (float)Sqrt(obj.Radius * obj.Radius - d * d);
                t0 = Tca - Thc;
                t1 = Tca + Thc;
                if (t0 < tToPoint && t0 > 0) tToPoint = t0;
                if (t1 < tToPoint && t1 > 0) tToPoint = t1;
                colorOutput = obj.Color * tToPoint;
            }
            viewablePoint = start + tToPoint * vec;



        }
    }
}

