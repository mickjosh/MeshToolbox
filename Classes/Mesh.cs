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
    }
}
