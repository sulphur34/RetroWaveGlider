using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.TerrainSystem
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class TerrainMesh : MonoBehaviour
    {
        private int _xSize;
        private int _ySize = 1;
        private Mesh _mesh;
        private MeshFilter _meshFilter;
        private MeshRenderer _meshRenderer;
        private Vector3[] _vertices;
        private TerrainData _terrainData;
        private int[] _triangles;

        public event Action<Vector2[]> TerrainChanged;

        public float XDelta => _terrainData.XDelta;
        public float YDelta => _terrainData.YDelta;
        public float YStart => _terrainData.YStart;
        public float XStart { get; private set; }
        public Vector3 LastVertex => _vertices.Last();

        public void Initialize(TerrainData terrainData)
        {
            _terrainData = terrainData;
            _xSize = _terrainData.XSize;
            XStart = _terrainData.XStart;
            _meshFilter = GetComponent<MeshFilter>();
            _meshRenderer = GetComponent<MeshRenderer>();
            _mesh = new Mesh();
            _meshRenderer.material.SetColor("Terrain", Color.black);
            CreateQuads();
        }

        public void MoveMesh(Vector3 vertex1, Vector3 vertex2)
        {
            ModifyMesh((vertices) =>
            {
                AddEdge(vertex1, vertex2, vertices);
                RemoveEdge(vertices);
            });
        }

        public void AddEdge(Vector3 vertex1, Vector3 vertex2, List<Vector3> vertices)
        {
            AddToList(vertices, vertex1, vertex2);
            _xSize++;
        }

        public void RemoveEdge(List<Vector3> vertices)
        {
            RemoveFromList(vertices);
            XStart += XDelta;
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
            CreateVertices();
            CreateTriangles();
            ResetMesh();
        }

        private void CreateVertices()
        {
            _vertices = new Vector3[(_xSize + 1) * (_ySize + 1)];
            float y = YStart;

            for (int i = 0, iy = 0; iy <= _ySize; iy++)
            {
                float x = XStart;

                for (int ix = 0; ix <= _xSize; i++, ix++, x += XDelta)
                {
                    _vertices[i] = new Vector2(x, y);
                }

                y += YDelta;
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
            List<Vector3> vertices = _vertices.ToList();
            modifyMesh(vertices);
            ResetMesh();
            _vertices = vertices.ToArray();
            CreateTriangles();
        }

        private void ResetMesh()
        {
            _mesh.Clear();
            _mesh.vertices = _vertices;
            _mesh.triangles = _triangles;
            _meshFilter.mesh = _mesh;
            TerrainChanged?
                .Invoke(GetSurface());
        }

        private Vector2[] GetSurface()
        {
            return _vertices.Select((vertex) => new Vector2(vertex.x, vertex.y))
                .Skip(_vertices.Length / 2)
                .ToArray();
        }
    }
}