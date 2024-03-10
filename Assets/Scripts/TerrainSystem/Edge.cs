using UnityEngine;

namespace TerrainSystem
{
    public class Edge
    {
        public Edge(Vector3 baseVertex, Vector3 surfaceVertex)
        {
            BaseVertex = baseVertex;
            SurfaceVertex = surfaceVertex;
        }

        public Vector3 BaseVertex { get; private set; }
        public Vector3 SurfaceVertex { get; private set; }
    }
}
