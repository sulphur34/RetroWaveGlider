using System;
using UnityEngine;

public class MeshCreator : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    Vector2[] uv;
    int quadCount = 1;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateQuad();
    }

    void CreateQuad()
    {
        vertices = new Vector3[]
        {
            new Vector3(quadCount - 1, 0, 0),
            new Vector3(quadCount, 0, 0),
            new Vector3(quadCount - 1, 1, 0),
            new Vector3(quadCount, 1, 0)
        };

        triangles = new int[]
        {
            (quadCount - 1) * 4, (quadCount - 1) * 4 + 2, (quadCount - 1) * 4 + 1,
            (quadCount - 1) * 4 + 2, (quadCount - 1) * 4 + 3, (quadCount - 1) * 4 + 1
        };

        uv = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
    }

    void AddQuad()
    {
        quadCount++;
        Vector3[] newVertices = new Vector3[vertices.Length + 4];
        vertices.CopyTo(newVertices, 0);

        for (int i = 0; i < 4; i++)
        {
            newVertices[vertices.Length + i] = new Vector3(quadCount - 1, i / 2f, 0);
        }

        vertices = newVertices;

        int[] newTriangles = new int[triangles.Length + 6];
        triangles.CopyTo(newTriangles, 0);

        for (int i = 0; i < 6; i++)
        {
            newTriangles[triangles.Length + i] = (quadCount - 1) * 4 + triangles[i];
        }

        triangles = newTriangles;

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    void RemoveQuad()
    {
        if (quadCount > 1)
        {
            quadCount--;
            Array.Resize(ref vertices, vertices.Length - 4);
            Array.Resize(ref triangles, triangles.Length - 6);

            mesh.vertices = vertices;
            mesh.triangles = triangles;
        }
    }

    // Example usage in Update method
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddQuad();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RemoveQuad();
        }
    }
}