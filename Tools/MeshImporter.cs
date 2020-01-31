using System.Collections.Generic;

namespace MeshToolbox.Tools
{
    /// <summary>
    /// The mesh importer tool
    /// </summary>
    public static class MeshImporter
    {
        /// <summary>
        /// Import a mesh from a file
        /// </summary>
        /// <param name="Path">The path of the mesh</param>
        /// <param name="Type">The type of the mesh</param>
        /// <returns>The mesh from the file</returns>
        public static Mesh Import(string Path, MeshFormat Type)
        {
            List<Vector3> vertex = new List<Vector3>();
            List<Vector3> normals = new List<Vector3>();
            List<Vector2> uvs = new List<Vector2>();
            List<int> triangles = new List<int>();

            return new Mesh(vertex.ToArray(), normals.ToArray(), uvs.ToArray(), triangles.ToArray());
        }

        /// <summary>
        /// Generate a mesh from a file of the obj format
        /// </summary>
        /// <param name="Path">The path of the obj</param>
        /// <returns>The mesh</returns>
        private static Mesh ImportOBJ(string Path)
        {
            string name = "";

            List<Vector3> vertex = new List<Vector3>();
            List<Vector3> normals = new List<Vector3>();
            List<Vector2> uvs = new List<Vector2>();
            List<int> triangles = new List<int>();

            foreach(var line in System.IO.File.ReadAllLines(Path))
            {
                //Continue to the next line if the line is a comment or empty 
                if(line.Contains("#") || string.IsNullOrEmpty(line))
                {
                    continue;
                }

                string[] split = line.Split(' ');

                if ((split[0] == "o" || split[0] == "g") && name == "")
                {
                    name = split[1];
                }
                else if (split[0] == "v")
                {
                    vertex.Add(new Vector3(double.Parse(split[1]), double.Parse(split[2]), double.Parse(split[3])));
                }
                else if (split[0] == "vn")
                {
                    normals.Add(new Vector3(double.Parse(split[1]), double.Parse(split[2]), double.Parse(split[3])));
                }
                else if (split[0] == "vt")
                {
                    uvs.Add(new Vector2(double.Parse(split[1]), double.Parse(split[2])));
                }
                else if (split[0] == "f")
                {
                    string[] triangleSplit = split[1].Split('/');

                    if(triangleSplit.Length == 1)
                    {
                        triangles.Add(int.Parse(split[1]));
                        triangles.Add(int.Parse(split[2]));
                        triangles.Add(int.Parse(split[3]));
                    }
                    else if (triangleSplit.Length == 2)
                    {

                    }
                    else if(triangleSplit.Length == 3)
                    {
                        if(normals.Count >= 1)
                        {

                        }
                        else
                        {

                        }
                    }
                }
            }

            if (name == "")
                name = "mesh";

            return new Mesh(vertex.ToArray(), normals.ToArray(), uvs.ToArray(), triangles.ToArray(), name);
        }
        /// <summary>
        /// Generate a mesh from a file of the stl format
        /// </summary>
        /// <param name="Path">The path of the stl</param>
        /// <returns>The mesh</returns>
        private static Mesh ImportSTL(string Path)
        {
            List<Vector3> vertex = new List<Vector3>();
            List<Vector3> normals = new List<Vector3>();
            List<int> triangles = new List<int>();

            return new Mesh(vertex.ToArray(), normals.ToArray(),  triangles.ToArray());
        }
    }
}
