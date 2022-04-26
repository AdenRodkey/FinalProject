using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MapGeneration : MonoBehaviour
{
    //Vector3 for the vertices.
    Vector3[] vertices;
    //Array to hold triangles.
    int[] triangles;
    //A mesh for the actual map generation for the vertices and triangles later on.
    Mesh mesh;
    
    //X and Z variables to limit the size of the mesh.
    public int xSize;
    public int zSize;


    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        CreateShape();
        MeshUpdater();
    }

 

   //Function to actually create the mesh shape.
   //Uses vertices to connect into a triangle shape, and then duplicates it to make polys or squares.
   //It then loops through the x and z axes to change the y value with Perlin Noise to add a differential terrain (think hills and dips)
    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

 
        for(int i = 0, z = 0; z <= zSize; z++)
        {
            for(int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .4f, z * .4f) * 2f + Mathf.PerlinNoise(x * .2f, z * .2f) * 1f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

       
        triangles = new int[xSize * zSize * 6];

        int verts = 0;
        int tris = 0;

        //Main Loop that loops through both the x and z size variables to connect the triangles together into polys on the x axis.
        //Then goes out to the z axis to fill in an entire square grid (for this purpose its a square)
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = verts + 0;
                triangles[tris + 1] = verts + xSize + 1;
                triangles[tris + 2] = verts + 1;
                triangles[tris + 3] = verts + 1;
                triangles[tris + 4] = verts + xSize + 1;
                triangles[tris + 5] = verts + xSize + 2;

                verts++;
                tris += 6;
            }
            verts++;
        }
        
    }
    //Updates the mesh and sets the mesh's vertices created earlier to the triangles and vertices below.
    //Then recalculates normals. 
    //
    void MeshUpdater()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
 
}
