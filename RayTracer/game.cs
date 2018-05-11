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
            // Drawing the Red Seperation line in the middle
            screen.Line(screen.width / 2, 0, screen.width / 2, screen.height, 0xff0000);
        }

        // Converting X axis position to actual pixel location on screen
        public int TX(float b, bool Left)
        {
            int x;
            b += 2;
            x = (int)(b * 0.25f * (screen.width / 2));
            if (Left == true)
                return x;
            else
                return x + (screen.width / 2);
        }

        // Converting Y axis position to actual pixel location on screen
        public int TY(float b)
        {
            int y;
            b = b * aspectratio;
            b -= 2;
            y = (int)(b * -0.25f * screen.height);
            return y;
        }
    }

} // namespace Template