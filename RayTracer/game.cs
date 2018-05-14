using System;
using System.IO;
using template.Elements.Primitives;
using OpenTK;
using template.Elements;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

namespace Template {

    class Game
    {
	    // member variables
	    public Surface screen;
        float aspectratio;

	    // initialize
	    public void Init()
	    {
            aspectratio = screen.width / screen.height;
        }
        // tick: renders one frame
        public void Tick()
        {
            screen.Clear(0);
            screen.Line(screen.width / 2, 0, screen.width / 2, screen.height, 0xff0000);
            screen.Print("X", screen.width - 25, screen.height /2 + 10, 0xffffff);
            screen.Print("Z", screen.width / 4 * 3+ 5, screen.height - 20, 0xffffff);
            // Drawing the Red Seperation line in the middle     
        }

        public void RenderGL()
        {
            // prepare for generic OpenGL rendering
            GL.Enable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Texture2D);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            float FOV =  1;
            Scene Scene1 = new Scene();
            Scene1.toggleaxis(true);
            if (Scene1.Axis == true)
            {
                GL.Color4(1f, 1f, 1f, 1f);
                GL.Begin(PrimitiveType.Lines);
                GL.Vertex2(0.5f, 1); GL.Vertex2(0.5f, -1f);
                GL.Vertex2(0, 0); GL.Vertex2(1, 0);
                GL.End();
            }
            Sphere Sphere1 = new Sphere(new Vector3(1, 1, 0), 0.07f, new Vector3(255,0,0), aspectratio);
            Sphere Sphere2 = new Sphere(new Vector3(0, 1, 0), 0.07f, new Vector3(0, 0, 255), aspectratio);
            Sphere Sphere3 = new Sphere(new Vector3(-1, 1, 0), 0.07f, new Vector3(0, 255,0), aspectratio);
            Camera mainCamera = new Camera(new Vector3(0,0,0), new Vector3(0,0,1), FOV);
            Light LightSource1 = new Light(new Vector3(-1.5f, 0, 0.4f), 255, 255, 0);
            Scene1.PrimitivesList.Add(Sphere1);
            Scene1.PrimitivesList.Add(Sphere2);
            Scene1.PrimitivesList.Add(Sphere3);
  
            Raytracer raytracer = new Raytracer();
            raytracer.Render(mainCamera, Scene1, screen);
        }
    }

} // namespace Template