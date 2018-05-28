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
        public Plane Screen;
        public Vector3 Position, Direction, ScreenCenter, Corner1, Corner2, Corner3 ;
        public float FOV;
        public Camera(Vector3 Pos, Vector3 Dir, float fov)
        {
            Position = Pos;
            Direction = Dir;
            FOV = fov;
            ScreenCenter = Pos + Dir * FOV;
            Corner1 = ScreenCenter + new Vector3(-256, 256, 0);
            Corner2 = ScreenCenter + new Vector3(256, 256, 0);
            Screen = new Plane(Dir, 1f, ScreenCenter);
            

            DrawCamPoint(Position);
            DrawScreen(ScreenCenter);
        }

        public static void DrawCamPoint(Vector3 Pos)
        {
            float x = Pos.X;
            float y = Pos.Z;
            x += 2;
            x *= 0.25f;
            y *= 0.5f;
            GL.Color4(1f, 1f, 1f, 1f);
            GL.PointSize(5f);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(x, y, 0);
            GL.End();
        }
        public static void DrawScreen(Vector3 ScreenCenter)
        {
            float ScreenWidth = 512;
            float ScreenHeight = 512; 
            float ycenter = ScreenCenter.Z;
            float xcenter = ScreenCenter.X;
            GL.Color4(1f, 1f, 1.0f, 1f);
            GL.LineWidth(1f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2((xcenter - ScreenWidth/2 + 256) / 512, ycenter/ (ScreenHeight/2));
            GL.Vertex2((xcenter + ScreenWidth/2 + 256 ) / 512, ycenter / (ScreenHeight/2));
            GL.End();

            /*
            ycam *= 0.5f;
            xcam += 2;
            xcam *= 0.25f;
            float zoffset = 0.2f;
            float y = ycam + zoffset;
            GL.Color4(1f, 1f, 1.0f, 1f);
            GL.LineWidth(1f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(xcam + (ScreenSize / 400), y);
            GL.Vertex2(xcam - (ScreenSize / 400), y);
            GL.End();
            */
        }      
    }
}