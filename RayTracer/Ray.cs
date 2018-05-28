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
        public Vector3 Color = new Vector3(0,0,0);
        public float Length;

        public Ray(Vector3 start, Vector3 vec, List<Primitives.Sphere> objects, float maxT)
        {
            Length = 1000;
            Color = new Vector3(0, 0, 0);
            foreach (Primitives.Sphere Sphere in objects)
            {
                Vector3 c = Sphere.Position - start;
                float t = Vector3.Dot(c.Normalized(), vec);
                t *= c.Length;
                Vector3 q = c - t * vec;
                float p = q.Length * q.Length;
                if (p > Sphere.Radius2)
                {
                    return;
                }
                if ((t < Length && t > 0))
                {
                    Length = t;
                    Color = Sphere.Color;
                }
            }
        }
    }
}

