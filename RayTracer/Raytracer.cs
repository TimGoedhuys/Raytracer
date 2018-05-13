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

        public void Render(Camera cam, Scene objects, Template.Surface screen)
        {
            float viewportX, viewportY, viewportZ;
            Vector3 startpoint, raydir;

            Primitives.Plane viewport = cam.Screen;
            for (int x = 0; x < screen.width / 2; x++)
            {
                for (int y = 0; y < screen.height; y++)
                {
                    //viewportX = 
                    startpoint = new Vector3(cam.FOV*(x-screen.width/2), cam.FOV*(y-screen.height/2),0);
                    raydir = startpoint - cam.Position;
                    Ray ray = new Ray(startpoint, raydir, objects.PrimitivesList, 10f);
                    DrawRay(startpoint,ray.viewablePoint);
                    screen.pixels[y * screen.width / 2 + x] = Hex(ray.colorOutput);
                }
            }

        }

        public int Hex(Vector3 vecColor)
        {
            return (int)(256 * 256 * vecColor.X + 256 * vecColor.Y + vecColor.Z);
        }

        void DrawRay(Vector3 a, Vector3 b)
        {
            float xa = a.X;
            float ya = a.Z;
            xa += 2;
            xa *= 0.25f;
            ya *= 0.5f;
            float xb = b.X;
            float yb = b.Z;
            xb += 2;
            xb *= 0.25f;
            yb *= 0.5f;
            GL.Begin(PrimitiveType.Lines);
            GL.Color4(1f,1f,0f,1f);
            GL.Vertex2(xb,yb);
            GL.Vertex2(0,0);
            GL.End();
            GL.Disable(EnableCap.Blend);


        }
    }
}
