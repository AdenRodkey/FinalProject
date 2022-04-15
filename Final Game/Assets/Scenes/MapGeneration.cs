using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MapGeneration : MonoBehaviour
{
    
    Vector3[] vertices;
    int[] triangles;
    Mesh mesh;

    public int xSize = 100;
    public int zSize = 100;


    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        MeshUpdater();
    }

 

   
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
    void MeshUpdater()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
 
}
