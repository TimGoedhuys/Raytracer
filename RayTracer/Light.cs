using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template.Elements
{
    class Light
    {
        Vector3 Position;
        float Red, Green, Blue;
        public Light (Vector3 Pos, float r, float g, float b)
        {
            Position = Pos;
            Red = r;
            Green = g;
            Blue = b;
        }
    }
}
