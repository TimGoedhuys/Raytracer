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
        public float Length , Lengthshadow;
        public float angle;
        public int i = 0, j = 0;
        public bool Intersect = false , Shadow = false;

        public Ray(Vector3 start, Vector3 vec, List<Primitives.Sphere> objects, float maxT, float [,] Intersections, Light Light)
        {
            //viewdistance is no more than 1000 in this case 
            Length = 1000;

            //standard color is bkack
            Color = new Vector3(0, 0, 0);    
        }

        public Vector3 Primarycolor(List<Primitives.Sphere> objects, Vector3 start, Vector3 vec)
        {
            int i = 0;
            Vector3 Color = new Vector3(0,0,0);
            while (i < objects.Count)
            {

                Vector3 c = objects[i].Position - start;
                float t = Vector3.Dot(c, vec);
                if (t < 0)
                {
                    i++;
                }

                Vector3 q = c - t * vec;
                float p = Vector3.Dot(q, q);

                if ((t < this.Length && t > 0)  && p < objects[i].Radius2)
                {
                    this.Length = t;
                    Intersect = true;
                    Color = objects[i].Color;
                    i++;
                }
                else
                {
                    i++;
                }
            }
            return Color;
        }

        public float CheckCollisionShadowRay(List<Primitives.Sphere> objects, Vector3 start, Vector3 vec, Light Light)
        {
            float shadow = 1;
            Lengthshadow = 1000;
            j = 0;
            while (Shadow == false && j < objects.Count)
            {
                // start shadow ray just outside of the sphere
                Vector3 c = (objects[j].Position - vec * 0.001f) - (start + vec * 0.001f);
                float t = Vector3.Dot(c, vec);

                Vector3 ray = Light.Position - start;
                Lengthshadow = ray.Length;

                Vector3 q = c - t * vec;
                float p = Vector3.Dot(q, q);

                if ((t < Lengthshadow && t > 0) && p < objects[j].Radius2)
                {
                    Shadow = true;
                    Lengthshadow = t;
                    shadow = 0;
                }

                if (Shadow == false)
                {
                    j++;
                }
            }
            return shadow;
        }

        public float CalcAngle()
        {
            return 1;
        }
        public float CalcIntensity()
        {
            return 1;
        }
    }
}

