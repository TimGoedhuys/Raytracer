using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.Elements.Primitives;

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
        }
    }
}
