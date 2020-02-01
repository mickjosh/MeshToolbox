using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshToolbox.Tools
{
    /// <summary>
    /// The mesh fusion tool
    /// </summary>
    public static class MeshFusion
    {
        /// <summary>
        /// Make a fusion betwen 2 mesh
        /// </summary>
        /// <param name="mesh1">The first mesh to use in the fusion</param>
        /// <param name="mesh2">The second mesh to use in the fusion</param>
        /// <returns>The result mesh of the fusion</returns>
        public static Mesh Fusion(Mesh mesh1, Mesh mesh2)
        {
            return Fusion(mesh1, mesh2, mesh1.name + "_" + mesh2.name);
        }
        /// <summary>
        /// Make a fusion betwen 2 mesh
        /// </summary>
        /// <param name="mesh1">The first mesh to use in the fusion</param>
        /// <param name="mesh2">The second mesh to use in the fusion</param>
        /// <param name="newName">The name of the new mesh</param>
        /// <returns>The result mesh of the fusion</returns>
        public static Mesh Fusion(Mesh mesh1, Mesh mesh2, string newName)
        {
            List<Vector3> newVertex = new List<Vector3>();
            newVertex = newVertex.Concat(mesh1.vertex).Concat(mesh2.vertex).ToList();

            List<Vector3> newNormals = new List<Vector3>();
            newNormals = newNormals.Concat(mesh1.normals).Concat(mesh2.normals).ToList();

            List<Vector2> newUvs = new List<Vector2>();
            newUvs = newUvs.Concat(mesh1.uvs).Concat(mesh2.uvs).ToList();

            List<int> newTriangle = new List<int>();
            newTriangle = newTriangle.Concat(mesh1.triangles).ToList();

            int vertexCount = mesh1.vertex.Length;
            foreach(var t in mesh2.triangles)
            {
                newTriangle.Add(t + vertexCount);
            }

            return new Mesh(newVertex.ToArray(), newNormals.ToArray(), newUvs.ToArray(), newTriangle.ToArray(), newName);
        }
    }
}
