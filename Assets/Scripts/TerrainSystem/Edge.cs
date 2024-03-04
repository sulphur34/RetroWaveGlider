using System.Numerics;

namespace Assets.Scripts.TerrainSystem
{
    public class Edge
    {
        public Edge(Vector3 vertex1, Vector3 vertex2)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }

        public Vector3 Vertex1 { get; private set; }
        public Vector3 Vertex2 { get; private set; }
    }
}
