using System;

namespace MeshToolbox
{
    /// <summary>
    /// The enum that contain all suported mesh format
    /// </summary>
    public enum MeshFormat
    {
        Obj,
        Stl,
        StlB
    }

    /// <summary>
    /// The class that contain all the data of a mesh
    /// </summary>
    public class Mesh
    {
        #region Constructor
        public Mesh()
        {
            name = "mesh";

            _vertex = new Vector3[0];
            _normals = new Vector3[0];
            _uvs = new Vector2[0];
            _triangles = new int[0];
        }
        public Mesh(Vector3[] Vertex, int[] Triangles, string Name = "mesh")
        {
            name = Name;

            if (Triangles.Length % 3 != 0)
            {
                //Throw Error
            }

            _vertex = Vertex;
            _normals = new Vector3[0];
            _uvs = new Vector2[0];
            _triangles = Triangles;
        }
        public Mesh(Vector3[] Vertex, Vector3[] Normals, int[] Triangles, string Name = "mesh")
        {
            name = Name;

            if ((Vertex.Length != Normals.Length) && Normals.Length != 0)
            {
                //Throw Error
            }
            else if (Triangles.Length % 3 != 0)
            {
                //Throw Error
            }

            _vertex = Vertex;
            _normals = Normals;
            _uvs = new Vector2[0];
            _triangles = Triangles;
        }
        public Mesh(Vector3[] Vertex, Vector2[] Uvs, int[] Triangles, string Name = "mesh")
        {
            name = Name;

            if ((Vertex.Length != Uvs.Length) && Uvs.Length != 0)
            {
                //Throw Error
            }
            else if (Triangles.Length % 3 != 0)
            {
                //Throw Error
            }

            _vertex = Vertex;
            _normals = new Vector3[0];
            _uvs = Uvs;
            _triangles = Triangles;
        }
        public Mesh(Vector3[] Vertex, Vector3[] Normals, Vector2[] Uvs, int[] Triangles, string Name = "mesh")
        {
            name = Name;

            if ((Normals.Length != Vertex.Length) && Normals.Length != 0)
            {
                //Throw Error
            }
            else if ((Uvs.Length != Vertex.Length) && Uvs.Length != 0)
            {
                //Throw Error
            }
            else if (Triangles.Length % 3 != 0)
            {
                //Throw Error
            }

            _vertex = Vertex;
            _normals = Normals;
            _uvs = Uvs;
            _triangles = Triangles;
        }
        #endregion

        #region Variables
        public string name;

        public Vector3[] vertex
        {
            get
            {
                return _vertex;
            }
        }
        private Vector3[] _vertex;

        public Vector3[] normals
        {
            get
            {
                return _normals;
            }
        }
        private Vector3[] _normals;

        public Vector2[] uvs
        {
            get
            {
                return _uvs;
            }
        }
        private Vector2[] _uvs;

        public int[] triangles
        {
            get
            {
                return _triangles;
            }
        }
        private int[] _triangles;

        public Vector3 scale
        {
            get
            {
                return _scale;
            }
        }
        private Vector3 _scale = Vector3.zero;
        #endregion

        /// <summary>
        /// Check if the current mesh contain normals
        /// </summary>
        /// <returns>If the mesh contain normals</returns>
        public bool ContainNormals()
        {
            return normals.Length == vertex.Length;
        }
        /// <summary>
        /// Check if the current mesh contain uvs
        /// </summary>
        /// <returns>If the current mesh contain uvs</returns>
        public bool ContainUvs()
        {
            return uvs.Length == vertex.Length;
        }

        /// <summary>
        /// Remove unused vertex, normal and uv
        /// </summary>
        public void Clean()
        {
            //Do the cleaning proccess
        }

        /// <summary>
        /// Scale the mesh relative from its original size
        /// </summary>
        /// <param name="scale">The new size of the mesh</param>
        public void ScaleMesh(double scale)
        {
            ScaleMesh((Vector3)scale);
        }
        /// <summary>
        /// Scale the mesh relative from its original size
        /// </summary>
        /// <param name="scale">The new size of the mesh</param>
        public void ScaleMesh(Vector3 scale)
        {
            int vertexCount = vertex.Length;

            Vector3 mul = new Vector3((1.0 / _scale.x) * scale.x, (1.0 / _scale.y) * scale.y, (1.0 / _scale.z) * scale.z);
            for (int i = 0; i < vertexCount; i++)
            {
                _vertex[i] *= mul;
            }

            _scale = scale;
        }

        /// <summary>
        /// Translate the mesh
        /// </summary>
        /// <param name="translation">How much to translate the mesh</param>
        public void TranslateMesh(Vector3 translation)
        {
            for(int i = 0; i < _vertex.Length; i++)
            {
                _vertex[i] += translation;
            }
        }
        /// <summary>
        /// Rotate the mesh
        /// </summary>
        /// <param name="rotation">How much to rotate the mesh in radian</param>
        public void Rotate(Vector3 rotation)
        {
            var cosa = Math.Cos(rotation.y);
            var sina = Math.Sin(rotation.y);

            var cosb = Math.Cos(rotation.x);
            var sinb = Math.Sin(rotation.x);

            var cosc = Math.Cos(rotation.z);
            var sinc = Math.Sin(rotation.z);

            var Axx = cosa * cosb;
            var Axy = cosa * sinb * sinc - sina * cosc;
            var Axz = cosa * sinb * cosc + sina * sinc;

            var Ayx = sina * cosb;
            var Ayy = sina * sinb * sinc + cosa * cosc;
            var Ayz = sina * sinb * cosc - cosa * sinc;

            var Azx = -sinb;
            var Azy = cosb * sinc;
            var Azz = cosb * cosc;

            for (var i = 0; i < _vertex.Length; i++)
            {
                var px = _vertex[i].x;
                var py = _vertex[i].y;
                var pz = _vertex[i].z;

                _vertex[i].x = Axx * px + Axy * py + Axz * pz;
                _vertex[i].y = Ayx * px + Ayy * py + Ayz * pz;
                _vertex[i].z = Azx * px + Azy * py + Azz * pz;
            }
        }

        /// <summary>
        /// Clone the current mesh into a new one
        /// </summary>
        /// <returns>The cloned Mesh</returns>
        public Mesh Clone()
        {
            return new Mesh((Vector3[])_vertex.Clone(), (Vector3[])_normals.Clone(), (Vector2[])_uvs.Clone(), (int[])_triangles.Clone(), name);
        }

        public override string ToString()
        {
            return $"Vertex: {_vertex.Length} Triangles: {_triangles.Length / 3}";
        }
    }
}
