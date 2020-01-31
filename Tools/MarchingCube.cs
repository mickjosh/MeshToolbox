using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshToolbox.Tools
{
    /// <summary>
    /// A tools to make mesh from points
    /// </summary>
    public static class MarchingCube
    {
        /// <summary>
        /// Generate a mesh from a points cloud
        /// </summary>
        /// <param name="Points">All the point to generate the mesh from</param>
        /// <param name="Resolution">How many cube to use (in each axis ex: (1000 X 1000 X 1000))</param>
        /// <returns>The generated mesh</returns>
        public static Mesh GenerateMesh(List<Vector3> Points, int Resolution)
        {
            return new Mesh();
        }
    }
}
