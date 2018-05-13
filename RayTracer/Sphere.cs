using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using template.Elements;
using System.IO;

namespace template.Elements.Primitives
{
    class Sphere: Primitive
    {
        public Vector3 Position, Color;
        public float Radius;
        public Sphere(Vector3 Pos, float Rad, Vector3 Colr, float Ratio): base("Sphere")
        {
            Position = Pos;
            Radius = Rad;
            Color = Colr;

            DrawCircle(Position.X, Position.Y, Radius, Color, Ratio);
        }

        public static void DrawCircle(float x, float y, float radius, Vector3 c, float Ratio)
        {
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color4(c.X, c.Y, c.Z, 1.0f);
            x += 2;
            x *= 0.25f;
            y *= 0.5f;

            GL.Vertex2(x, y);
            for (int i = 0; i < 360; i++)
            {
                GL.Vertex2(x + Math.Cos(i) * radius, y + Math.Sin(i) * radius * Ratio);
            }

            GL.End();
            GL.Disable(EnableCap.Blend);
        }
    }
}
