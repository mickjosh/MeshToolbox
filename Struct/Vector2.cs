using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshToolbox
{
    public struct Vector2
    {
        #region Constructor
        public Vector2(double X, double Y)
        {
            x = X;
            y = Y;
        }
        #endregion

        #region Variables
        public static Vector2 zero = new Vector2(0, 0);
        public static Vector2 one = new Vector2(1, 1);

        public double x;
        public double y;

        public double magnitude
        {
            get
            {
                return Math.Sqrt(sqrMagnitude);
            }
        }
        public double sqrMagnitude
        {
            get
            {
                return Math.Pow(x, 2) + Math.Pow(y, 2);
            }
        }

        public Vector2 normalized
        {
            get
            {
                return this / magnitude;
            }
        }
        #endregion

        #region Operator
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }
        public static Vector2 operator +(Vector2 v1, double d)
        {
            return new Vector2(v1.x + d, v1.y + d);
        }
        public static Vector2 operator +(double d, Vector2 v1)
        {
            return v1 + d;
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }
        public static Vector2 operator -(Vector2 v1, double d)
        {
            return new Vector2(v1.x - d, v1.y - d);
        }
        public static Vector2 operator -(double d, Vector2 v1)
        {
            return new Vector2(d - v1.x, d - v1.y);
        }

        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x * v2.x, v1.y * v2.y);
        }
        public static Vector2 operator *(Vector2 v1, double d)
        {
            return new Vector2(v1.x * d, v1.y * d);
        }
        public static Vector2 operator *(double d, Vector2 v1)
        {
            return v1 * d;
        }

        public static Vector2 operator /(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x / v2.x, v1.y / v2.y);
        }
        public static Vector2 operator /(Vector2 v1, double d)
        {
            return new Vector2(v1.x / d, v1.y / d);
        }
        public static Vector2 operator /(double d, Vector2 v1)
        {
            return new Vector2(d / v1.x, d / v1.y);
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return v1.x == v2.x && v1.y == v2.y;
        }
        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return v1.x != v2.x || v1.y != v2.y;
        }

        public static bool operator >(Vector2 v1, Vector2 v2)
        {
            return v1.magnitude > v2.magnitude;
        }
        public static bool operator >(Vector2 v1, double d)
        {
            return v1.magnitude > d;
        }
        public static bool operator >(double d, Vector2 v1)
        {
            return d > v1.magnitude;
        }

        public static bool operator <(Vector2 v1, Vector2 v2)
        {
            return v1.magnitude < v2.magnitude;
        }
        public static bool operator <(Vector2 v1, double d)
        {
            return v1.magnitude < d;
        }
        public static bool operator <(double d, Vector2 v1)
        {
            return d < v1.magnitude;
        }

        public static bool operator >=(Vector2 v1, Vector2 v2)
        {
            return v1.magnitude >= v2.magnitude;
        }
        public static bool operator >=(Vector2 v1, double d)
        {
            return v1.magnitude >= d;
        }
        public static bool operator >=(double d, Vector2 v1)
        {
            return d >= v1.magnitude;
        }

        public static bool operator <=(Vector2 v1, Vector2 v2)
        {
            return v1.magnitude <= v2.magnitude;
        }
        public static bool operator <=(Vector2 v1, double d)
        {
            return v1.magnitude <= d;
        }
        public static bool operator <=(double d, Vector2 v1)
        {
            return d < v1.magnitude;
        }

        public override bool Equals(object obj)
        {
            return obj is Vector2 vector &&
                   x == vector.x &&
                   y == vector.y;
        }
        public override int GetHashCode()
        {
            var hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }

        #region Cast
        public static explicit operator Vector3(Vector2 vec)
        {
            return new Vector3(vec.x, vec.y, 0);
        }
        public static explicit operator double(Vector2 vec)
        {
            return vec.magnitude;
        }
        public static explicit operator Vector2(double d)
        {
            return new Vector2(d, d);
        }
        #endregion
        #endregion
    }
}
