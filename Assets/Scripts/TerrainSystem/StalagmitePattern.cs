using UnityEngine;

namespace TerrainSystem
{
    public class StalagmitePattern : Pattern
    {
        private readonly float _minOffset = 0.25f;
        private readonly float _maxOffset = 1.5f;
        private bool _isSameHeight = false;
        
        public override void GenerateTerrain(TerrainMesh terrainMesh,float minConstrain, float maxConstrain)
        {
            Edge edge = terrainMesh.LastEdge;
            Vector3 baseVertex;
            Vector3 surfaceVertex;
            float offsetValue = Random.Range(_minOffset, _maxOffset);
            float newXPosition = edge.SurfaceVertex.x + terrainMesh.XDelta;

            if (_isSameHeight)
            {
                baseVertex = new Vector3(newXPosition, terrainMesh.YStart);
                surfaceVertex = new Vector3(newXPosition, edge.SurfaceVertex.y);
            }
            else
            {
                float newYPosition = edge.SurfaceVertex.y + Random.Range(-offsetValue, offsetValue);
                newYPosition = Mathf.Clamp(newYPosition, minConstrain, maxConstrain);
                baseVertex = new Vector3(newXPosition, terrainMesh.YStart);
                surfaceVertex = new Vector3(newXPosition, newYPosition);
            }

            terrainMesh.MoveMesh(new Edge(baseVertex, surfaceVertex));
            _isSameHeight = !_isSameHeight;
        }
    }
}