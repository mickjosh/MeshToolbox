using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshToolbox.Tools
{
    /// <summary>
    /// The primitive mesh tool
    /// </summary>
    public static class Primitive
    {
        /// <summary>
        /// Generate the mesh of a cube
        /// </summary>
        /// <param name="Size">The size of each side</param>
        /// <returns>The mesh of the cube</returns>
        public static Mesh CreateCube(Vector3 Size)
        {
            Vector3[] vertices = new Vector3[] {
                new Vector3(0, 0, 0) , 
                new Vector3(0, 1, 0) * Size, 
                new Vector3(1, 1, 0) * Size,
                new Vector3(1, 0, 0) * Size, 
                                            
                new Vector3(1, 0, 1) * Size, 
                new Vector3(1, 1, 1) * Size, 
                new Vector3(0, 1, 1) * Size, 
                new Vector3(0, 0, 1) * Size,
                                            
                new Vector3(1, 0, 0) * Size, 
                new Vector3(1, 1, 0) * Size, 
                new Vector3(1, 1, 1) * Size,
                new Vector3(1, 0, 1) * Size,
                                           
                new Vector3(0, 0, 1) * Size, 
                new Vector3(0, 1, 1) * Size, 
                new Vector3(0, 1, 0) * Size, 
                new Vector3(0, 0, 0),
                                            
                new Vector3(0, 1, 0) * Size, 
                new Vector3(0, 1, 1) * Size, 
                new Vector3(1, 1, 1) * Size, 
                new Vector3(1, 1, 0) * Size,
                                           
                new Vector3(0, 0, 0), 
                new Vector3(0, 0, 1) * Size,
                new Vector3(1, 0, 1) * Size, 
                new Vector3(1, 0, 0) * Size};

            Vector3[] normals = new Vector3[]
            {
                new Vector3( 0, 0,-1),
                new Vector3( 0, 0,-1),
                new Vector3( 0, 0,-1),
                new Vector3( 0, 0,-1),

                new Vector3( 0, 0, 1),
                new Vector3( 0, 0, 1),
                new Vector3( 0, 0, 1),
                new Vector3( 0, 0, 1),

                new Vector3( 1, 0, 0),
                new Vector3( 1, 0, 0),
                new Vector3( 1, 0, 0),
                new Vector3( 1, 0, 0),

                new Vector3(-1, 0, 0),
                new Vector3(-1, 0, 0),
                new Vector3(-1, 0, 0),
                new Vector3(-1, 0, 0),

                new Vector3( 0, 1, 0),
                new Vector3( 0, 1, 0),
                new Vector3( 0, 1, 0),
                new Vector3( 0, 1, 0),

                new Vector3( 0,-1, 0),
                new Vector3( 0,-1, 0),
                new Vector3( 0,-1, 0),
                new Vector3( 0,-1, 0)
            };

            Vector2[] uv = new Vector2[] {
                new Vector2(0, 0),    
                new Vector2(0, 1),    
                new Vector2(1, 1),    
                new Vector2 (1, 0),
                                  
                new Vector2(0, 0),    
                new Vector2(0, 1),    
                new Vector2(1, 1),    
                new Vector2 (1, 0),
                                  
                new Vector2(0, 0),    
                new Vector2(0, 1),    
                new Vector2(1, 1),    
                new Vector2 (1, 0),
                                  
                new Vector2(0, 0),    
                new Vector2(0, 1),    
                new Vector2(1, 1),    
                new Vector2 (1, 0),
                                  
                new Vector2(0, 0),    
                new Vector2(0, 1),    
                new Vector2(1, 1),    
                new Vector2 (1, 0),
                                  
                new Vector2(0, 0),    
                new Vector2(0, 1),    
                new Vector2(1, 1),    
                new Vector2 (1, 0)
            };
            
            int[] triangles = new int[] 
            { 
                0, 1, 2,
                0, 2, 3,
                4, 5, 6,
                4, 6, 7,
                8, 9, 10,
                8, 10, 11,
                12, 13, 14,
                12, 14, 15,
                16, 17, 18,
                16, 18, 19,
                20, 21, 22,
                20, 22, 23 
            };

            return new Mesh(vertices, normals, uv, triangles, "Cube");
        }
        /// <summary>
        /// Generate the mesh of a cube
        /// </summary>
        /// <param name="Size">The eize of the side</param>
        /// <returns>The mesh of the cube</returns>
        public static Mesh CreateCube(double Size)
        {
            return CreateCube(new Vector3(Size, Size, Size));
        }

        /// <summary>
        /// Generate the mesh of a cylinder
        /// </summary>
        /// <param name="BottomRadius">The radius of the botom of the cylinder</param>
        /// <param name="TopRadius">The radius of the Top of the cylinder</param>
        /// <param name="Height">The height of the cylinder</param>
        /// <returns>The mesh of the cylinder</returns>
        public static Mesh CreateCylinder(double BottomRadius, double TopRadius, double Height, int Resolution)
        {
            return new Mesh();
        }
        /// <summary>
        /// Generate the mesh of a cylinder
        /// </summary>
        /// <param name="Radius">The radius of the cylinder</param>
        /// <param name="Height">The height of the cylinder</param>
        /// <param name="Resolution">The amount of side</param>
        /// <returns>The mesh of the cylinder</returns>
        public static Mesh CreateCylinder(double Radius, double Height, double Resolution)
        {
            return CreateCylinder(Radius, Radius, Height, Resolution);
        }

        /// <summary>
        /// Generate the mesh of a tube
        /// </summary>
        /// <param name="BottomInnerRadius">The inner radius of the botom of the tube</param>
        /// <param name="BottomOuterRadius">The outer radius of the botom of the tube</param>
        /// <param name="TopInnerRadius">The inner radius of the top of the tube</param>
        /// <param name="TopOuterRadius">The outer radius of the top of the tube</param>
        /// <param name="Height">The height of the tube</param>
        /// <param name="Resolution">The amount of side</param>
        /// <returns>The mesh of the tube</returns>
        public static Mesh CreateTube(double BottomInnerRadius, double BottomOuterRadius, double TopInnerRadius, double TopOuterRadius, double Height, int Resolution)
        {
            return new Mesh();
        }
        /// <summary>
        /// Generate the mesh of a tube
        /// </summary>
        /// <param name="InnerRadius">The inner radius of the tube</param>
        /// <param name="OuterRadius">The outer radius of the tube</param>
        /// <param name="Height">The height of the tube</param>
        /// <param name="Resolution">The amount of side</param>
        /// <returns>The mesh of the tube</returns>
        public static Mesh CreateTube(double InnerRadius, double OuterRadius, double Height, int Resolution)
        {
            return CreateTube(InnerRadius, InnerRadius, OuterRadius, OuterRadius, Height, Resolution);
        }

        /// <summary>
        /// Generate the mesh of a cylinder
        /// </summary>
        /// <param name="Radius">The radius of the cone</param>
        /// <param name="Height">The height of the cone</param>
        /// <param name="Resolution">The amount of side</param>
        /// <returns>The mesh of the cone</returns>
        public static Mesh CreateCone(double Radius, double Height, int Resolution)
        {
            return new Mesh();
        }
        
        /// <summary>
        /// Generate the mesh of a torus
        /// </summary>
        /// <param name="MajorRadius"></param>
        /// <param name="MinorRadius"></param>
        /// <param name="MajorResolution"></param>
        /// <param name="MinorResolution"></param>
        /// <returns>The mesh of the torus</returns>
        public static Mesh CreateTorus(double MajorRadius, double MinorRadius, int MajorResolution, int MinorResolution)
        {
            /*
            Major Radius
            Radius from the origin to the center of the cross sections.
            Minor Radius
            Radius of the torus’ cross section.
            */

            return new Mesh();
        }

        /// <summary>
        /// Generate the mesh of a sphere
        /// </summary>
        /// <param name="Radius">The radius of the sphere</param>
        /// <param name="Resolution">The amount of side</param>
        /// <returns>The mesh of the sphere</returns>
        public static Mesh CreateSphere(double Radius, int Resolution)
        {
            return new Mesh();
        }

        /// <summary>
        /// Generate the mesh of a icosphere
        /// </summary>
        /// <param name="Radius">The radius of the icosphere</param>
        /// <param name="Subdivison">How many recursions to generate the mesh</param>
        /// <returns>The mesh of the icosphere</returns>
        public static Mesh CreateIcoSphere(double Radius, int Subdivison)
        {
            return new Mesh();
        }
    }
}
