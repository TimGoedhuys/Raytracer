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
            // Drawing the Red Seperation line in the middle     
        }

        public void RenderGL()
        {
            // prepare for generic OpenGL rendering
            GL.Enable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Texture2D);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            Sphere Sphere1 = new Sphere(new Vector3(1, 1, 0), 0.07f, new Vector3(255,0,0), aspectratio);
            Sphere Sphere2 = new Sphere(new Vector3(0, 1, 0), 0.07f, new Vector3(0, 0, 255), aspectratio);
            Sphere Sphere3 = new Sphere(new Vector3(-1, 1, 0), 0.07f, new Vector3(0, 255,0), aspectratio);
            Camera Camara = new Camera(new Vector3(0,0,0), new Vector3(0,0,1));
            Light LightSource1 = new Light(new Vector3(-1.5f, 0, 0.4f), 255, 255, 0);
        }
    }

} // namespace Template