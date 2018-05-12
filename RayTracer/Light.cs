using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace template.Elements
{
    class Light
    {
        Vector3 Position;
        float Red, Green, Blue;
        public Light(Vector3 Pos, float r, float g, float b)
        {
            Position = Pos;
            Red = r;
            Green = g;
            Blue = b;

            DrawLight(Position, Red, Green , Blue);
        }

        void DrawLight(Vector3 Pos, float r, float g, float b)
        {
            float x = Pos.X;
            float y = Pos.Z;
            x += 2;
            x *= 0.25f;
            y *= 0.5f;

            GL.Color4(r, g, b, 1f);
            GL.PointSize(5f);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(x, y, 0);
            GL.End();
        }
    }
}
