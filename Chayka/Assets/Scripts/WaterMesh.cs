using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMesh : MonoBehaviour {

    public int segments;
    public int waves;
    public float speed;
    public float height;
    public float width;
    float step;
    Vector3 max;
    bool up;
    Mesh mesh;
    Vector3[] meshVertices;
    Vector2[] meshVertTriangle, baseuvs;
    public int[] newTriangles;

	// Use this for initialization
	void Start () {
        
        mesh = GetComponent<MeshFilter>().mesh;
        meshVertices = new Vector3[segments];
        meshVertTriangle = new Vector2[segments];
        mesh.triangles = newTriangles;
        baseuvs = new Vector2[]
        {
            new Vector2 (0,0),
            new Vector2(0,1),
            new Vector2(0.125f,1),
            new Vector2(0.25f,1),
            new Vector2(0.375f,1),
            new Vector2(0.5f,1),
            new Vector2(0.625f,1),
            new Vector2(0.75f,1),
            new Vector2(0.875f,1),
            new Vector2(1,1),
            new Vector2(1,0)
        };
        step = width/8;
        for (int i = 1; i<segments-1; i++)
        {
            meshVertices[i] = new Vector3(transform.position.x + step*(i-1), transform.position.y+height);
            meshVertTriangle[i] = meshVertices[i];
        }
        meshVertices[segments - 1] = new Vector3(transform.position.x + width, transform.position.y);
        meshVertices[0] = new Vector3(transform.position.x, transform.position.y);
        meshVertTriangle[segments - 1] = meshVertices[segments - 1];
        meshVertTriangle[0] = meshVertices[0];

        Triangulator tr = new Triangulator(meshVertTriangle);
        newTriangles = tr.Triangulate();
        mesh.vertices = meshVertices;
        mesh.triangles = newTriangles;
        mesh.uv = baseuvs;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 1; i < segments - 1; i++)
        {
            meshVertices[i] = new Vector3(transform.position.x + step * (i - 1), transform.position.y + height);
            meshVertTriangle[i] = meshVertices[i];
        }

        Triangulator tr = new Triangulator(meshVertTriangle);
        newTriangles = tr.Triangulate();
        mesh.vertices = meshVertices;
        mesh.triangles = newTriangles;
        mesh.uv = baseuvs;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
	}
}
