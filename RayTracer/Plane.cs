using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template.Elements.Primitives
{
    class Plane: Primitive
    {
        Vector3 Normal, Color;
        public float Dist2Origin;
        public Plane(Vector3 Norm, float Dist, Vector3 Colr): base("Plane")
        {
            Normal = Norm;
            Dist2Origin = Dist;
            Color = Colr;          
        }
    }
}
