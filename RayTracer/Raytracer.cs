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
        public float[,] Intersections = new float[512 + 512 * 512, 2];
        Vector3 FinalColor;
        public void Render(Camera cam, Scene Scene, Template.Surface screen)
        {
            // Shoot a ray through every pixel

            Vector3 startpoint, raydir;
            for (int y = 0; y < screen.height; y++)
            {
                for (int x = 0; x < screen.width/2; x++)
                {
                    startpoint = cam.Position;
                    Vector3 ScreenPixel = cam.Corner1 + new Vector3(x, -y, 0);
                    raydir = ScreenPixel - startpoint;
                    raydir.Normalize();

                    // create the ray with all variables needed
                    Ray ray1 = new Ray(startpoint, raydir, Scene.PrimitivesList, 10f,Intersections, Scene.LightList[0]);
                    Vector3 PrimeColor = ray1.Primarycolor(Scene.PrimitivesList, startpoint, raydir);

                    // draw every 10th ray in the debug window
                    if (x % 10 == 0 && y  == 256)
                    {
                        DrawRay(startpoint, raydir, ray1.Length);
                    }

                    // check for shadows if there was an intersection
                    if (ray1.Intersect == true)
                    {
                        Vector3 ShadowRay = Scene.LightList[0].Position - (startpoint + raydir * ray1.Length);

                        // if there is a shadow on this point CheckCollisionShadowRay() will return 0 wich makes the pixel black on the next line
                        float Shadow = ray1.CheckCollisionShadowRay(Scene.PrimitivesList, startpoint +  raydir * ray1.Length, ShadowRay.Normalized(), Scene.LightList[0]);
                        FinalColor = PrimeColor * Shadow;
                    }
                    else
                    {
                        FinalColor = PrimeColor;
                    }

                    // calculating other factors (intensity, angle)
                    if (FinalColor != new Vector3(0, 0, 0))
                    {
                        float Angle = ray1.CalcAngle();
                        float Intensity = ray1.CalcIntensity();

                        // angle and intensity both return 1 (not enough time to make it work)
                        FinalColor *= Angle * Intensity;
                    }
                    int Color = CreateColor((int)FinalColor.X, (int)FinalColor.Y, (int)FinalColor.Z);
                    Image[x + y * 512] = Color;
                }
            }
            
        }

        // Draws the rays in the Debug window
        void DrawRay(Vector3 start, Vector3 end, float length)
        {
            float xstart = (start.X + 256) / 512;
            float ystart = (start.Z) / 256;
            float xend = (end.X * length + start.X + 256) /512;
            float yend = (end.Z * length + start.Z) /256;
            GL.Begin(PrimitiveType.Lines);
            GL.Color4(1f, 1f, 0f, 1f);
            GL.Vertex2(xstart, ystart);
            GL.Vertex2(xend, yend);
            GL.End();
        }

        // makes a int value of RGB values
        int CreateColor(int red, int green, int blue)
        {
            return ((red) << 16) + ((green) << 8) + (blue);
        }
    }
}
