using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Template;

namespace template.Elements
{
    class Scene
    {
        public bool Axis = false;
        public List<Primitives.Sphere> PrimitivesList = new List<Primitives.Sphere>();
        public List<Light> LightList = new List<Light>();

        public Vector3 Intersection()
        {
            return new Vector3(0,0,0);
        }

        public void toggleaxis(bool TF)
        {
            if (TF == true)
            {
                Axis = true;
            }
            else
            {
                Axis = false;
            }
        }

        public void DrawCircle(Vector2 Position, Vector3 Color, float Radius, Surface Screen)
        {
                float Ratio = Screen.width / Screen.height;
                GL.Begin(PrimitiveType.TriangleFan);
                GL.Color4(Color.X, Color.Y, Color.Z, 1.0f);

                GL.Vertex2(Position.X, Position.Y);
                for (int i = 0; i < 360; i++)
                {
                    GL.Vertex2(Position.X + Math.Cos(i) * Radius, Position.Y + Math.Sin(i) * Radius * Ratio);
                }

                GL.End();
                GL.Disable(EnableCap.Blend);
        }
    }
}
