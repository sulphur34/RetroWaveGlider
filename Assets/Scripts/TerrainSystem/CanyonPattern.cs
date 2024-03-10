using UnityEngine;

namespace TerrainSystem
{
    public class CanyonPattern : Pattern
    {
        private int _offsetValue = 0;
        private int _patternRepeatValue = 0;

        public override void GenerateTerrain(TerrainMesh terrainMesh,float minConstrain, float maxConstrain)
        {
            Edge lastEdge = terrainMesh.LastEdge;

            if (_patternRepeatValue <= 0)
            {
                _offsetValue = Random.Range(-1, 2);
                _patternRepeatValue = Random.Range(1, 5);
            }

            _patternRepeatValue--;
            float newXPosition = lastEdge.SurfaceVertex.x + terrainMesh.XDelta;
            float newYPosition = lastEdge.SurfaceVertex.y + terrainMesh.XDelta * _offsetValue;
            newYPosition = Mathf.Clamp(newYPosition, minConstrain, maxConstrain);
            Vector3 baseVertex = new Vector3(newXPosition, terrainMesh.YStart);
            Vector3 surfaceVertex = new Vector3(newXPosition, newYPosition);
            terrainMesh.MoveMesh(new Edge(baseVertex, surfaceVertex));
        }
    }
}
