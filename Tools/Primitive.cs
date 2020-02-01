using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshToolbox.Tools
{
    public static class Primitive
    {
        private static Mesh CreateCube(Vector3 Size, Vector3 Center)
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
    }
}
