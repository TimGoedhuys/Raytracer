using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.Elements.Primitives;
using OpenTK.Graphics.OpenGL;

namespace template.Elements
{
    class Camera
    {
        Plane Screen;
        Vector3 Position, Direction;
        public Camera(Vector3 Pos, Vector3 Dir)
        {
            Position = Pos;
            Direction = Dir;
            Screen = new Plane(new Vector3(0, 0, 1), 0f, new Vector3(0, 0, 0));

            DrawCamPoint(Position);
            DrawScreen(Position);
        }

        public static void DrawCamPoint(Vector3 Pos)
        {
            float x = Pos.X;
            float y = Pos.Z;
            x += 2;
            x *= 0.25f;
            y *= 0.5f;
            y -= 0.5f;
            GL.Color4(0.0f, 1f, 0.0f, 1f);
            GL.PointSize(5f);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(x, y, 0);
            GL.End();
        }
        public static void DrawScreen(Vector3 CamPos)
        {
            float ScreenSize = 80, Screendistance = 80;
            float ycam = CamPos.Z;
            float xcam = CamPos.X;
            ycam *= 0.5f;
            ycam -= 0.5f;
            xcam += 2;
            xcam *= 0.25f;
            float zoffset = Screendistance / 200;
            float y = ycam + zoffset;
            GL.Color4(0, 0, 1.0f, 1f);
            GL.LineWidth(1f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(xcam + (ScreenSize / 400), y);
            GL.Vertex2(xcam - (ScreenSize / 400), y);
            GL.End();
        }      
    }
}