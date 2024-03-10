using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TerrainSystem
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
        private Verticies _vertices;
        private TerrainData _terrainData;
        private int[] _triangles;

        public event Action<Vector2[]> TerrainChanged;

        public float XDelta => _terrainData.XDelta;
        public float YDelta => _terrainData.YDelta;
        public float YStart => _terrainData.YStart;
        public float XStart { get; private set; }
        public Edge LastEdge => _vertices.LastEdge;

        public void Initialize(TerrainData terrainData)
        {
            _terrainData = terrainData;
            _xSize = _terrainData.XSize;
            XStart = _terrainData.XStart;
            _meshFilter = GetComponent<MeshFilter>();
            _meshRenderer = GetComponent<MeshRenderer>();
            _mesh = new Mesh();
            CreateQuads();
        }

        public void MoveMesh(Edge edge)
        {
            _vertices.Move(edge);
            _xSize++;
            XStart += XDelta;
            _xSize--;
            ResetMesh();
            CreateTriangles();
        }
        
        private void CreateQuads()
        {
            CreateVertices();
            CreateTriangles();
            ResetMesh();
        }

        private void CreateVertices()
        {
            Vector3[] vertices = new Vector3[(_xSize + 1) * (_ySize + 1)];
            float y = YStart;

            for (int i = 0, iy = 0; iy <= _ySize; iy++)
            {
                float x = XStart;

                for (int ix = 0; ix <= _xSize; i++, ix++, x += XDelta)
                {
                    vertices[i] = new Vector2(x, y);
                }

                y += YDelta;
            }

            _vertices = new Verticies(vertices);
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

        private void ResetMesh()
        {
            _mesh.Clear();
            _mesh.vertices = _vertices.Get;
            _mesh.triangles = _triangles;
            _meshFilter.mesh = _mesh;
            TerrainChanged?
                .Invoke(_vertices.Surface);
        }
    }
}