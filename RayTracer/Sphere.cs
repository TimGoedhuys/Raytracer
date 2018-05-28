using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using template.Elements;
using System.IO;
using Template;

namespace template.Elements.Primitives
{
    class Sphere: Primitive
    {
        public Vector3 Position, Color;
        public float Radius, Radius2;
        public Sphere(Vector3 Pos, float Rad, Vector3 Colr, float Ratio): base("Sphere")
        {
            Position = Pos;
            Radius = Rad;
            Color = Colr;
            Radius2 = Rad * Rad;
        }
    }
}
