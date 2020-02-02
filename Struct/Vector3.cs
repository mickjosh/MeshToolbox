using System;

namespace MeshToolbox
{
    public struct Vector3
    {
        #region Constructor
        public Vector3(double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
        }
        #endregion

        #region Variables
        public static Vector3 zero = new Vector3(0, 0, 0);
        public static Vector3 one = new Vector3(1, 1, 1);

        public static Vector3 unitX = new Vector3(1, 0, 0);
        public static Vector3 unitY = new Vector3(0, 1, 0);
        public static Vector3 unitZ = new Vector3(0, 0, 1);

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
        #endregion

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
        public static explicit operator Vector3(double d)
        {
            return new Vector3(d, d, d);
        }
        #endregion
        #endregion

        /// <summary>
        /// Return a cross product of 2 vector
        /// </summary>
        /// <param name="v">The other vector to do the cross product</param>
        /// <returns>The cross product</returns>
        public Vector3 Cross(Vector3 v)
        {
            double crossX = y * v.z - z * v.y;
            double crossY = z * v.x - x * v.z;
            double crossZ = x * v.y - y * v.x;

            return new Vector3(crossX, crossY, crossZ);
        }
        /// <summary>
        /// Return a cross product of 2 vector
        /// </summary>
        /// <param name="v1">The first vector to do the cross product</param>
        /// <param name="v2">The second vector to do the cross product</param>
        /// <returns>The cross product</returns>
        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            return v1.Cross(v2);
        }
        /// <summary>
        /// Return a dot product of 2 vector
        /// </summary>
        /// <param name="v">The other vector to do the dot product</param>
        /// <returns>The dot product</returns>
        public double Dot(Vector3 v)
        {
            return (x * v.x) + (y * v.y) + (z * v.z);
        }
        /// <summary>
        /// Return a dot product of 2 vector
        /// </summary>
        /// <param name="v1">The first vector to do the dot product</param>
        /// <param name="v2">The second vector to do the dot product</param>
        /// <returns>The dot product</returns>
        public static double Dot(Vector3 v1, Vector3 v2)
        {
            return v1.Dot(v2);
        }

        public override string ToString()
        {
            return $"({x.ToString(".0")}, {y.ToString(".0")}, {z.ToString(".0")})";
        }
    }
}
