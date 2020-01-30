using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshToolbox.Tools
{
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
                    ExportOBJ(Mesh);
                    break;

                case MeshFormat.Stl:
                    ExportSTL(Mesh);
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
            return "";
        }
        /// <summary>
        /// Generate a string that contain the mesh in the stl format
        /// </summary>
        /// <param name="Mesh">The mesh to export</param>
        /// <returns>The mesh in stl format</returns>
        private static string ExportSTL(Mesh Mesh)
        {
            return "";
        }
    }
}
