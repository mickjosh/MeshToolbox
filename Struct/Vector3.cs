using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshToolbox
{
    public struct Vector3
    {
        public Vector3(double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public static Vector3 zero = new Vector3(0, 0, 0);
        public static Vector3 one = new Vector3(1, 1, 1);

        public double x;
        public double y;
        public double z;

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
                return Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2);
            }
        }

        public Vector3 normalized
        {
            get
            {
                return this / magnitude;
            }
        }

        #region Operator
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        public static Vector3 operator +(Vector3 v1, double d)
        {
            return new Vector3(v1.x + d, v1.y + d, v1.z + d);
        }
        public static Vector3 operator +(double d, Vector3 v1)
        {
            return v1 + d;
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }
        public static Vector3 operator -(Vector3 v1, double d)
        {
            return new Vector3(v1.x - d, v1.y - d, v1.z - d);
        }
        public static Vector3 operator -(double d, Vector3 v1)
        {
            return new Vector3(v1.x - d, v1.y - d, v1.z - d);
        }

        public static Vector3 operator *(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }
        public static Vector3 operator *(Vector3 v1, double d)
        {
            return new Vector3(v1.x * d, v1.y * d, v1.z * d);
        }
        public static Vector3 operator *(double d, Vector3 v1)
        {
            return v1 * d;
        }

        public static Vector3 operator /(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }
        public static Vector3 operator /(Vector3 v1, double d)
        {
            return new Vector3(v1.x / d, v1.y / d, v1.z / d);
        }
        public static Vector3 operator /(double d, Vector3 v1)
        {
            return new Vector3(d / v1.x, d / v1.y, d / v1.z);
        }

        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            return v1.x == v2.x && v1.y == v2.y && v1.z == v2.z;
        }
        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return v1.x != v2.x || v1.y != v2.y || v1.z != v2.z;
        }

        public static bool operator >(Vector3 v1, Vector3 v2)
        {
            return v1.magnitude > v2.magnitude;
        }
        public static bool operator >(Vector3 v1, double d)
        {
            return v1.magnitude > d;
        }
        public static bool operator >(double d, Vector3 v1)
        {
            return d > v1.magnitude;
        }

        public static bool operator <(Vector3 v1, Vector3 v2)
        {
            return v1.magnitude < v2.magnitude;
        }
        public static bool operator <(Vector3 v1, double d)
        {
            return v1.magnitude < d;
        }
        public static bool operator <(double d, Vector3 v1)
        {
            return d < v1.magnitude;
        }

        public static bool operator >=(Vector3 v1, Vector3 v2)
        {
            return v1.magnitude >= v2.magnitude;
        }
        public static bool operator >=(Vector3 v1, double d)
        {
            return v1.magnitude >= d;
        }
        public static bool operator >=(double d, Vector3 v1)
        {
            return d >= v1.magnitude;
        }

        public static bool operator <=(Vector3 v1, Vector3 v2)
        {
            return v1.magnitude <= v2.magnitude;
        }
        public static bool operator <=(Vector3 v1, double d)
        {
            return v1.magnitude <= d;
        }
        public static bool operator <=(double d, Vector3 v1)
        {
            return d < v1.magnitude;
        }

        public override bool Equals(object obj)
        {
            return obj is Vector3 vector &&
                   x == vector.x &&
                   y == vector.y &&
                   z == vector.z;
        }
        public override int GetHashCode()
        {
            var hashCode = 373119288;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + z.GetHashCode();
            return hashCode;
        }

        #region Cast
        public static explicit operator Vector2(Vector3 vec)
        {
            return new Vector2(vec.x, vec.y);
        }
        public static explicit operator double(Vector3 vec)
        {
            return vec.magnitude;
        }
        #endregion
        #endregion
    }
}
