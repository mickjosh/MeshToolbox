namespace MeshToolbox.Tools
{
    /// <summary>
    /// The normals generating tool
    /// </summary>
    public static class NormalsGenerator
    {
        /// <summary>
        /// Generate Normal for a mesh
        /// </summary>
        /// <param name="mesh">The mesh to generate normal from</param>
        public static void GenerateNormals(this Mesh mesh)
        {
            int[] triangles = mesh.triangles;
            int triangleCount = triangles.Length / 3;

            Vector3[] normals = mesh.normals;
            Vector3[] vertex = mesh.vertex;

            for (int i = 0; i < normals.Length; i++)
            {
                normals[i] = Vector3.zero;
            }

            for (int i = 0; i < triangleCount; i++)
            {
                Vector3 n = Vector3.Cross(vertex[1+(3*i)] - vertex[0+(3*i)], vertex[2+(3*i)] - vertex[0+(3*i)]).normalized;

                normals[0 + (3 * i)] += n;
            }

            for(int i = 0; i < normals.Length; i++)
            {
                normals[i] = normals[i].normalized;
            }
        }
    }
}
