using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshToolbox
{
    public struct Vector2
    {
        public Vector2(double X, double Y)
        {
            x = X;
            y = Y;
        }

        public static Vector2 zero = new Vector2(0, 0);
        public static Vector2 one = new Vector2(1, 1);

        public double x;
        public double y;
    }
}
