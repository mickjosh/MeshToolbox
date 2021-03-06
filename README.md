# MeshToolbox
- Import Mesh
- Export Mesh
- Mesh Fusion
- Marching Cube
- Primitive Mesh
- Normals Generator

## Import Mesh
This tool let you import OBJ, STL and Binary STL

```csharp
  Mesh mesh = MeshImporter.Import("ParentPath/Mesh.format");
  
  or
  
  Mesh mesh = MeshImporter.Import("ParentPath/Mesh.format", MeshFormat.Format);
```

## Export Mesh
This tool let you export OBJ, STL and Binary STL

```csharp
  MeshExporter.Export(Mesh, "ParentPath/Mesh.format");
  
  or
  
  MeshExporter.Export(Mesh, "ParentPath/Mesh.format", MeshFormat.Format);
```

## Mesh Fusion
This tool let you fusionate 2 mesh together

```csharp
  Mesh mesh = MeshFusion.Fusion(Mesh1, Mesh2);
```

## Marching Cube
This tool let you make a mesh from a points cloud with the marching cube algorithm

```csharp
  Mesh mesh = MarchingCube.GenerateMesh(Points, Resolution);
```

## Primitive Mesh
This tool let you make primitive mesh (Cube, Cylinder, Cone , Sphere, Torus)

```csharp
  Mesh mesh = Primitive.CreateShape(ShapeParams);
```

## Normals Generator
This tool let you generate normal for a mesh

```csharp
  mesh.GenerateNormals();
```
