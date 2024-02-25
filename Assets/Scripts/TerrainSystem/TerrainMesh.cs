using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent (typeof(MeshRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class TerrainMesh : MonoBehaviour
{
    private int _xSize;    
    private int _ySize;
    private Mesh _mesh;
    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;
    private Vector3[] _verticies;
    private int[] _triangles;
    private float _xDelta;
    private float _yDelta;
    private EdgeCollider2D _polygonCollider;

    public float YStart { get; private set; }
    public float XStart { get; private set; }
    public Vector3 LastVertice => _verticies.Last();

    public void Initialize(float xStart, float yStart, float xDelta, float yDelta, int xSize, int ySize = 1)
    {
        _ySize = ySize;
        _xSize = xSize;
        _xDelta = xDelta;
        _yDelta = yDelta;
        XStart = xStart;
        YStart = yStart;
        _polygonCollider = GetComponent<EdgeCollider2D>();
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _mesh = new Mesh();
        _meshRenderer.material.SetColor("Terrain",Color.black);
        CreateQuads();
    }

    public void MoveMesh(Vector3 vertice1, Vector3 vertice2)
    {
        ModifyMesh((verticies) =>
        {
            AddEdge(vertice1, vertice2, verticies);
            RemoveEdge(verticies);
        });
    }

    public void AddEdge(Vector3 vertice1, Vector3 vertice2, List<Vector3> verticies)
    {
        AddToList(verticies, vertice1, vertice2);        
        _xSize++;
    }

    public void RemoveEdge(List<Vector3> verticies)
    {
        RemoveFromList(verticies);
        XStart += _xDelta;
        _xSize--;
    }

    private void RemoveFromList<T>(List<T> list) where T : struct
    {
        int middleIndex = (list.Count / 2) - 1;
        list.RemoveAt(middleIndex + 1);
        list.RemoveAt(0);
    }

    private void AddToList<T>(List<T> list, T firstElement, T secondElement) where T : struct
    {
        int middleIndex = (list.Count / 2) - 1;
        list.Insert(middleIndex + 1, firstElement);
        list.Add(secondElement);
    }

    private void CreateQuads()
    {
        CreateVerticies();
        CreateTriangles();
        ResetMesh();

    }

    private void CreateVerticies()
    {
        _verticies = new Vector3[(_xSize + 1) * (_ySize + 1)];
        float y = YStart;

        for (int i = 0, iy = 0; iy <= _ySize; iy++)
        {
            float x = XStart;
            for (int ix = 0; ix <= _xSize; i++, ix++, x += _xDelta)
            {
                _verticies[i] = new Vector2(x, y);
            }

            y += _yDelta;
        }
    }

    private void CreateTriangles()
    {
        _triangles = new int[_xSize * _ySize * 6];

        for (int ti = 0, vi = 0, iy = 0; iy < _ySize; iy++, vi++)
        {
            for (int ix = 0; ix < _xSize; ix++, ti += 6, vi++)
            {
                _triangles[ti] = vi;
                _triangles[ti + 1] = _triangles[ti + 4] = vi + _xSize + 1;
                _triangles[ti + 2] = _triangles[ti + 3] = vi + 1;
                _triangles[ti + 5] = vi + _xSize + 2;
            }
        }
    }

    private void ModifyMesh(Action<List<Vector3>> modifyMesh)
    {
        List<Vector3> verticies = _verticies.ToList();
        modifyMesh(verticies);
        ResetMesh();
        _verticies = verticies.ToArray();
        CreateTriangles();
    }

    private void ResetMesh()
    {
        _mesh.Clear();
        _mesh.vertices = _verticies;
        _mesh.triangles = _triangles;
        _meshFilter.mesh = _mesh;
        _polygonCollider.points = _verticies.Select((vertice) =>  new Vector2(vertice.x,vertice.y)).Skip(_verticies.Length/2).ToArray();
    }
}
