using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshToolbox
{
    /// <summary>
    /// The enum that contain all suported mesh format
    /// </summary>
    public enum MeshFormat
    {
        Obj,
        Stl
    }

    /// <summary>
    /// The class that contain all the data of a mesh
    /// </summary>
    public class Mesh
    {
        #region Constructor
        public Mesh()
        {
            _vertex = new Vector3[0];
            _normals = new Vector3[0];
            _uvs = new Vector2[0];
            _triangles = new int[0];
        }
        public Mesh(Vector3[] Vertex, Vector3[] Normals, Vector2[] Uvs, int[] Triangles)
        {
            if (Normals.Length != Vertex.Length)
            {
                //Throw Error
            }
            else if (Uvs.Length != Vertex.Length)
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

        public Vector3 Scale
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
    }
}
