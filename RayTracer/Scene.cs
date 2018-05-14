using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Template;

namespace template.Elements
{
    class Scene
    {
        public bool Axis = false;
        public List<Primitives.Sphere> PrimitivesList = new List<Primitives.Sphere>();
        public List<Light> LightList = new List<Light>();

        public Vector3 Intersection()
        {
            return new Vector3(0,0,0);
        }

        public void toggleaxis(bool TF)
        {
            if (TF == true)
            {
                Axis = true;
            }
            else
            {
                Axis = false;
            }
        } 
    }
}
