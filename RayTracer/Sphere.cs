using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template.Elements.Primitives
{
    class Sphere: Primitive
    {
        Vector3 Position, Color;
        float Radius;
        public Sphere(Vector3 Pos, float Rad, Vector3 Colr): base("Sphere")
        {
            Position = Pos;
            Radius = Rad;
            Color = Colr; 
        }
    }
}
