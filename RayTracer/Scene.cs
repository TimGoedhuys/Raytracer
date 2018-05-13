using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template.Elements
{
    class Scene
    {
        public List<Primitives.Sphere> PrimitivesList = new List<Primitives.Sphere>();
        public List<Light> LightList = new List<Light>();

        public Vector3 Intersection()
        {
            return new Vector3(0,0,0);
        }
    }
}
