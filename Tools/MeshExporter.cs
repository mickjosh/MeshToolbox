﻿using System;
using System.Globalization;
using System.Text;

namespace MeshToolbox.Tools
{
    /// <summary>
    /// The mesh exporter tool
    /// </summary>
    public static class MeshExporter
    {
        /// <summary>
        /// Export the mesh to a file
        /// </summary>
        /// <param name="Mesh">The mesh to export</param>
        /// <param name="Path">The path where to export the mesh to</param>
        /// <param name="Type">The type of mesh to export to</param>
        public static void Export(Mesh Mesh, string Path, MeshFormat Type)
        {
            string text = "";

            switch(Type)
            {
                case MeshFormat.Obj:
                    text = ExportOBJ(Mesh);
                    break;

                case MeshFormat.Stl:
                    text = ExportSTL(Mesh);
                    break;
            }

            if(String.IsNullOrEmpty(text))
            {
                //Throw Error
            }

            System.IO.File.WriteAllText(Path, text);
        }
        /// <summary>
        /// Export the mesh to a file
        /// </summary>
        /// <param name="Mesh">The mesh to export</param>
        /// <param name="Path">The path where to export the mesh to</param>
        /// <param name="Type">The type of mesh to export to</param>
        public static void ExportMesh(this Mesh Mesh, string Path, MeshFormat Type)
        {
            Export(Mesh, Path, Type);
        }

        /// <summary>
        /// Generate a string that contain the mesh in the obj format
        /// </summary>
        /// <param name="Mesh">The mesh to export</param>
        /// <returns>The mesh in obj format</returns>
        private static string ExportOBJ(Mesh Mesh)
        {
            bool isNormals = false;
            bool isUvs = false;

            StringBuilder builder = new StringBuilder();

            //Add the header at the top of the file
            builder.AppendLine("#Mesh generated by the C# Mesh Toolbox");

            builder.AppendLine("");

            builder.AppendLine($"#Vertex Count =  {Mesh.vertex.Length}");
            builder.AppendLine($"#Triangle Count = {Mesh.triangles.Length / 3}");

            builder.AppendLine("");
            builder.AppendLine($"o {Mesh.name}");
            builder.AppendLine("");

            //Write the vertex data ex: "v 0.5 1.5 -0.3"
            foreach(var v in Mesh.vertex)
            {
                builder.AppendLine($"v {v.x.ToString(CultureInfo.InvariantCulture)} {v.y.ToString(CultureInfo.InvariantCulture)} {v.z.ToString(CultureInfo.InvariantCulture)}");
            }

            builder.AppendLine("");

            //Write the normal data(if contain any) ex: "vn 0.5 1.5 -0.3"
            if (Mesh.ContainNormals())
            {
                isNormals = true;

                foreach(var vn in Mesh.normals)
                {
                    builder.AppendLine($"vn {vn.x.ToString(CultureInfo.InvariantCulture)} {vn.y.ToString(CultureInfo.InvariantCulture)} {vn.z.ToString(CultureInfo.InvariantCulture)}");
                }

                builder.AppendLine("");
            }

            //Write the uv's data(if contain any) ex: "vt 0.5 1.5"
            if (Mesh.ContainUvs())
            {
                isUvs = true;

                foreach (var vt in Mesh.uvs)
                {
                    builder.AppendLine($"vn {vt.x.ToString(CultureInfo.InvariantCulture)} {vt.y.ToString(CultureInfo.InvariantCulture)}");
                }

                builder.AppendLine("");
            }
            int triangleCount = Mesh.triangles.Length;

            //Save the triangles in the correct format based on the optional component
            if (!isUvs && !isNormals)
            {            
                for(int i = 0; i < triangleCount; i += 3)
                {
                    builder.AppendLine($"f {Mesh.triangles[i] + 1} {Mesh.triangles[i + 1] + 1} {Mesh.triangles[i + 2] + 1}");
                }
            }
            else if (isNormals && !isUvs)
            {
                for (int i = 0; i < triangleCount; i += 3)
                {
                    int t1 = Mesh.triangles[i] + 1;
                    int t2 = Mesh.triangles[i + 1] + 1;
                    int t3 = Mesh.triangles[i + 2] + 1;

                    builder.AppendLine($"f {t1}/{t1} {t2}/{t2} {t3}/{t3}");
                }
            }
            else if (isUvs && !isNormals)
            {
                for (int i = 0; i < triangleCount; i += 3)
                {
                    int t1 = Mesh.triangles[i] + 1;
                    int t2 = Mesh.triangles[i + 1] + 1;
                    int t3 = Mesh.triangles[i + 2] + 1;

                    builder.AppendLine($"f {t1}//{t1} {t2}//{t2} {t3}//{t3}");
                }
            }
            else
            {
                for (int i = 0; i < triangleCount; i += 3)
                {
                    int t1 = Mesh.triangles[i] + 1;
                    int t2 = Mesh.triangles[i + 1] + 1;
                    int t3 = Mesh.triangles[i + 2] + 1;

                    builder.AppendLine($"f {t1}/{t1}/{t1} {t2}/{t2}/{t2} {t3}/{t3}/{t3}");
                }
            }

            return builder.ToString();
        }
        /// <summary>
        /// Generate a string that contain the mesh in the stl format
        /// </summary>
        /// <param name="Mesh">The mesh to export</param>
        /// <returns>The mesh in stl format</returns>
        private static string ExportSTL(Mesh Mesh)
        {
            //STL Required Normals
            if(!Mesh.ContainNormals())
            {
                //Throw Error
            }

            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"solid {Mesh.name.Replace(" ", "_")}");

            for(int i = 0; i < Mesh.triangles.Length; i += 3)
            {
                int t1 = Mesh.triangles[i];
                int t2 = Mesh.triangles[i + 1];
                int t3 = Mesh.triangles[i + 2];

                //Transform the normals from a vertex based to a facet based
                Vector3 normal = (Mesh.normals[t1] + Mesh.normals[t2] + Mesh.normals[t3]) / 3.0;

                Vector3 v1 = Mesh.vertex[t1];
                Vector3 v2 = Mesh.vertex[t2];
                Vector3 v3 = Mesh.vertex[t3];

                //Write all the data from a facet
                builder.AppendLine($"   facet normal {normal.x.ToString(CultureInfo.InvariantCulture)} {normal.y.ToString(CultureInfo.InvariantCulture)} {normal.z.ToString(CultureInfo.InvariantCulture)}");
                builder.AppendLine("        outer loop");
                builder.AppendLine($"           vertex {v1.x.ToString(CultureInfo.InvariantCulture)} {v1.y.ToString(CultureInfo.InvariantCulture)} {v1.z.ToString(CultureInfo.InvariantCulture)}");
                builder.AppendLine($"           vertex {v2.x.ToString(CultureInfo.InvariantCulture)} {v2.y.ToString(CultureInfo.InvariantCulture)} {v2.z.ToString(CultureInfo.InvariantCulture)}");
                builder.AppendLine($"           vertex {v3.x.ToString(CultureInfo.InvariantCulture)} {v3.y.ToString(CultureInfo.InvariantCulture)} {v3.z.ToString(CultureInfo.InvariantCulture)}");
                builder.AppendLine("        endloop");
                builder.AppendLine("    endfacet");
            }

            builder.AppendLine("endsolid");

            return builder.ToString();
        }
    }
}
