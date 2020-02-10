using System;
using System.Collections.Generic;
using System.Linq;

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
            //Import with the right algorhitm for the type of the file
            switch(Type)
            {
                case MeshFormat.Obj:
                    return ImportOBJ(Path);

                case MeshFormat.Stl:
                case MeshFormat.StlB:
                    return ImportSTL(Path);

                default:
                    //Throw Error
                    return new Mesh();
            }
        }
        /// <summary>
        /// Import a mesh from a file and auto detect the type
        /// </summary>
        /// <param name="Path">The path of the mesh</param>
        /// <returns>The mesh from the file</returns>
        public static Mesh Import(string Path)
        {
            string extension = System.IO.Path.GetExtension(Path);

            switch(extension)
            {
                case ".obj":
                    return ImportOBJ(Path);

                case ".stl":
                    return ImportSTL(Path);

                default:
                    //Throw Error
                    return new Mesh();
            }
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

                //Check what type of data there is on the current line
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

            //Add the default name if there was none into the file
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
            byte[] binaryFile = System.IO.File.ReadAllBytes(Path);

            if(System.Text.Encoding.UTF8.GetString(binaryFile).Contains("solid"))
            {
                //Binary STL

                return ImportSTLB(binaryFile, System.IO.Path.GetFileNameWithoutExtension(Path));
            }
            else
            {
                //ASCII STL

                List<Vector3> vertex = new List<Vector3>();
                List<Vector3> normals = new List<Vector3>();
                List<int> triangles = new List<int>();

                return new Mesh(vertex.ToArray(), ConvertNormalFormat(vertex, normals, triangles), triangles.ToArray(), System.IO.Path.GetFileNameWithoutExtension(Path));
            }
        }
        /// <summary>
        /// Generate a mesh from a file of the binary stl format
        /// </summary>
        /// <param name="Path">The path of the stl</param>
        /// <param name="MeshName">The name of the mesh</param>
        /// <returns>The mesh</returns>
        private static Mesh ImportSTLB(byte[] binaryFile, string MeshName)
        {
            /*
                UINT8[80] – en-tête
                UINT32 – Nombre de triangles

                foreach triangle
                    REAL32[3] – Vecteur normal
                    REAL32[3] – Sommet 1
                    REAL32[3] – Sommet 2
                    REAL32[3] – Sommet 3
                    UINT16 – Mot de contrôle
                end         
             */

            List<Vector3> vertex = new List<Vector3>();
            List<Vector3> normals = new List<Vector3>();
            List<int> triangles = new List<int>();

            uint triangleCount = BitConverter.ToUInt32(binaryFile, 80);

            //Byte Count = triangleCount * (12(Normal) + 36(3 Vertex) + 1(emptyByte))
            for(int i = 0; i < triangleCount; i++)
            {
                float nX = BitConverter.ToSingle(binaryFile, 84 + (i * 50));
                float nY = BitConverter.ToSingle(binaryFile, 88 + (i * 50));
                float nZ = BitConverter.ToSingle(binaryFile, 92 + (i * 50));

                normals.Add(new Vector3(nX, nY, nZ)); //12 Bytes

                for(int o = 0; o < 3; o++)
                {
                    float vX = BitConverter.ToSingle(binaryFile, 96 + (i * 50) + (o * 12));
                    float vY = BitConverter.ToSingle(binaryFile, 100 + (i * 50) + (o * 12));
                    float vZ = BitConverter.ToSingle(binaryFile, 104 + (i * 50) + (o * 12));

                    vertex.Add(new Vector3(vX, vY, vZ)); //12 Bytes
                } //3 * 12 Bytes (36 Bytes)

                triangles.Add(0 + (i * 3));
                triangles.Add(1 + (i * 3));
                triangles.Add(2 + (i * 3));
            }

            return new Mesh(vertex.ToArray(), ConvertNormalFormat(vertex, normals, triangles), triangles.ToArray(), MeshName);
        }

        /// <summary>
        /// Convert the normal from a face format to a vertex format
        /// </summary>
        /// <param name="vertex">The vertex of the mesh</param>
        /// <param name="normals">The normals in the face format of the mesh</param>
        /// <param name="triangles">The triangles of the mesh</param>
        /// <returns>The normals int the vertex format</returns>
        private static Vector3[] ConvertNormalFormat(List<Vector3> vertex, List<Vector3> normals, List<int> triangles)
        {
            Vector3[] newNormals = new Vector3[vertex.Count];

            for(int i = 0; i < triangles.Count / 3; i++)
            {
                newNormals[0 + (3 * i)] = normals[i];
                newNormals[1 + (3 * i)] = normals[i];
                newNormals[2 + (3 * i)] = normals[i];
            }

            return newNormals;
        }
    }
}
