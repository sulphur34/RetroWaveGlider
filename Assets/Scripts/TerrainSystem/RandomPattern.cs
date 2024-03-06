using UnityEngine;

namespace TerrainSystem
{
    public class RandomPattern : Pattern
    {
        public override void GenerateTerrain(TerrainMesh terrainMesh,float minConstrain, float maxConstrain)
        {
            Vector3 lastVertex = terrainMesh.LastVertex;
            float offsetValue = Random.Range(0.1f, 0.5f);
            float newXPosition = lastVertex.x + terrainMesh.XDelta;
            float newYPosition = lastVertex.y + Random.Range(-offsetValue, offsetValue);
            newYPosition = Mathf.Clamp(newYPosition, minConstrain, maxConstrain);
            Vector3 vertex1 = new Vector3(newXPosition, terrainMesh.YStart);
            Vector3 vertex2 = new Vector3(newXPosition, newYPosition);
            terrainMesh.MoveMesh(vertex1, vertex2);
        }
    }
}