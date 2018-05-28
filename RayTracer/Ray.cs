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
            
            // check every primitive on collision with primary ray           
            while (Intersect == false && i < objects.Count)
            {
                CheckCollision(objects, i, start, vec);
                if (Intersect == false)
                {
                    i++;
                }
            }

            //Only cast shadow ray if there is an intersection
            if (Intersect == true)
            {
                j = 0;
                Vector3 ShadowRay = Light.Position - vec * Length;

                // check every primitive on collision with Shadows ray
                while (Shadow == false && j < objects.Count)
                {
                    CheckCollisionShadowRay(objects, j, vec * Length, ShadowRay.Normalized(), i);
                    if (Shadow == false)
                    {
                        j++;
                    }
                }

                //If there is a shadow the pixel should be black
                if (Shadow == true)
                {
                    Color = new Vector3(0, 0, 0);
                }
                else
                {
                    // calculate the color knowing the angle to the sphere and the distance to the lightsource
                    //float intensity = Lengthshadow / 1000;
                    Vector3 normal = (vec * Length) - objects[i].Position;
                    angle = Vector3.Dot(normal, vec) * -100;
                    //Color *= intensity;
                    Color *= angle;
                }
            }                       
        }

        public void CheckCollision(List<Primitives.Sphere> objects, int i ,Vector3 start, Vector3 vec)
        {
            Vector3 c = objects[i].Position - start;
            float t = Vector3.Dot(c, vec);
            if (t < 0)
            {
                return;
            }
            Vector3 q = c - t * vec;
            float p = Vector3.Dot(q, q);
            if (p > objects[i].Radius2)
            {
                return;
            }
            //float diff = (objects[i].Radius2 - p) * (objects[i].Radius2 - p);
            //t -= diff;
            if ((t < Length && t > 0))
            {
                Length = t;
                Color = objects[i].Color;
                Intersect = true;
            }
        }
        public void CheckCollisionShadowRay(List<Primitives.Sphere> objects, int j, Vector3 start, Vector3 vec, int i)
        {
            // start shadow ray just outside of the sphere
            Vector3 c = (objects[j].Position - vec * 10) - (start + vec * 0.0001f);
            float t = Vector3.Dot(c, vec);
            if (t < 0)
            {
                return;
            }
            Vector3 q = c - t * vec;
            float p = q.Length * q.Length;
            if (p > objects[j].Radius2)
            {
                return;
            }
            //float diff = (objects[i].Radius2 - p) * (objects[i].Radius2 - p);
            //t -= diff;
            if ((t < Length && t > 0))
            {
                Shadow = true;
            }
            Lengthshadow = t;
        }
    }
}

