using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshToolbox.Tools
{
    public static class MeshImporter
    {
        /// <summary>
        /// Import a mesh from a file
        /// </summary>
        /// <param name="Path">The path of the mesh</param>
        /// <param name="Type">The type of the mesh</param>
        /// <returns>The mesh from the file</returns>
        public static Mesh Import(string Path, MeshType Type)
        {
            List<Vector3> vertex = new List<Vector3>();
            List<Vector3> normals = new List<Vector3>();
            List<Vector2> uvs = new List<Vector2>();
            List<int> triangles = new List<int>();

            return new Mesh(vertex.ToArray(), normals.ToArray(), uvs.ToArray(), triangles.ToArray());
        }
    }
}
