using UnityEngine;

namespace TerrainSystem
{
    public class RandomPattern : Pattern
    {
        public override void GenerateTerrain(TerrainMesh terrainMesh,float minConstrain, float maxConstrain)
        {
            Edge lastEdge = terrainMesh.LastEdge;
            float offsetValue = Random.Range(0.1f, 0.5f);
            float newXPosition = lastEdge.SurfaceVertex.x + terrainMesh.XDelta;
            float newYPosition = lastEdge.SurfaceVertex.y + Random.Range(-offsetValue, offsetValue);
            newYPosition = Mathf.Clamp(newYPosition, minConstrain, maxConstrain);
            Vector3 baseVertex = new Vector3(newXPosition, terrainMesh.YStart);
            Vector3 surfaceVertex = new Vector3(newXPosition, newYPosition);
            terrainMesh.MoveMesh(new Edge(baseVertex, surfaceVertex));
        }
    }
}