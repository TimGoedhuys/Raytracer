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
    class Raytracer
    {
        public float[] Image = new float[512 + 512*512];
        public void Render(Camera cam, Scene Scene, Template.Surface screen)
        {
            float viewportX, viewportY, viewportZ, i = 0;
            Vector3 startpoint, raydir;

            Primitives.Plane viewport = cam.Screen;
            for (int y = 0; y < screen.height; y++)
            {
                for (int x = 0; x < screen.width/2; x++)
                {
                    startpoint = cam.Position;
                    Vector3 ScreenPixel = cam.Corner1 + new Vector3(x, -y, 0);
                    raydir = ScreenPixel - startpoint;
                    raydir.Normalize();
                    Ray ray1 = new Ray(startpoint, raydir, Scene.PrimitivesList, 10f);
                    if (x % 32 == 0 && y  == 256)
                    {
                        DrawRay(startpoint, raydir, ray1.Length);
                    }
                    int Color = CreateColor((int)ray1.Color.X, (int)ray1.Color.Y, (int)ray1.Color.Z);
                    Image[x + y * 512] = Color;
                }
            }

        }

        public int Hex(Vector3 vecColor)
        {
            return (int)(256 * 256 * vecColor.X + 256 * vecColor.Y + vecColor.Z);
        }

        void DrawRay(Vector3 start, Vector3 end, float length)
        {
            float xstart = (start.X + 256) / 512;
            float ystart = (start.Z) / 256;
            float xend = (end.X * length + start.X + 256) /512;
            float yend = (end.Z * length + start.Z) /256;
            //if (xend < 0)
               //xend = 0;
            GL.Begin(PrimitiveType.Lines);
            GL.Color4(1f, 1f, 0f, 1f);
            GL.Vertex2(xstart, ystart);
            GL.Vertex2(xend, yend);
            GL.End();
        }

        int CreateColor(int red, int green, int blue)
        {
            return (red << 16) + (green << 8) + blue;
        }
    }
}
