using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TerrainSystem
{
    public class Verticies
    {
        private List<Vector3> _vertices;

        public Edge LastEdge => GetLastEdge();

        public Vector2[] Surface => GetSurface();

        public Vector3[] Get => _vertices.ToArray();

        private int MiddleIndex => (_vertices.Count / 2) - 1;

        public Verticies(Vector3[] verticies)
        {
            _vertices = verticies.ToList();
        }

        public void Move(Edge edge)
        {
            AddEdge(edge);
            RemoveFirstPair();
        }
        
        private void RemoveFirstPair()
        {
            int middleIndex = (_vertices.Count / 2) - 1;
            _vertices.RemoveAt(middleIndex + 1);
            _vertices.RemoveAt(0);
        }

        private void AddEdge(Edge edge)
        {
            _vertices.Insert(MiddleIndex + 1, edge.BaseVertex);
            _vertices.Add(edge.SurfaceVertex);
        }
        
        private Vector2[] GetSurface()
        {
            return _vertices.Select((vertex) => new Vector2(vertex.x, vertex.y))
                .Skip(_vertices.Count / 2)
                .ToArray();
        }

        private Edge GetLastEdge()
        {
            return new Edge(_vertices[MiddleIndex], _vertices.Last());
        }
    }
}