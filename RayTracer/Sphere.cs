using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

namespace template.Elements.Primitives
{
    class Sphere: Primitive
    {
        static Vector3 Position, Color;
        float Radius;
        public Sphere(Vector3 Pos, float Rad, Vector3 Colr): base("Sphere")
        {
            Position = Pos;
            Radius = Rad;
            Color = Colr;

            DrawCircle(Position.X, Position.Y, Radius, Color);
        }

        public static void DrawCircle(float x, float y, float radius, Vector3 c)
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color4(Color.X, Color.Y, Color.Z, 256);

            GL.Vertex2(x, y);
            for (int i = 0; i < 360; i++)
            {
                GL.Vertex2(x + Math.Cos(i) * radius, y + Math.Sin(i) * radius);
            }

            GL.End();
            GL.Disable(EnableCap.Blend);
        }
    }
}
