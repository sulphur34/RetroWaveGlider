using UnityEngine;

namespace TerrainSystem
{
    public class StalagmiteScenario : Scenario
    {
        private bool _isSameHeight = false;

        protected override void GenerateTerrain(TerrainMesh terrainMesh, float minConstrain, float maxConstrain)
        {
            Vector3 lastVertex = terrainMesh.LastVertex;
            Vector3 vertex1;
            Vector3 vertex2;
            float offsetValue = Random.Range(0.25f, 1f);
            float newXPosition = lastVertex.x + terrainMesh.XDelta;

            if (_isSameHeight)
            {
                vertex1 = new Vector3(newXPosition, terrainMesh.YStart);
                vertex2 = new Vector3(newXPosition, lastVertex.y);
            }
            else
            {
                float newYPosition = lastVertex.y + Random.Range(-offsetValue, offsetValue);
                newYPosition = Mathf.Clamp(newYPosition, minConstrain, maxConstrain);
                vertex1 = new Vector3(newXPosition, terrainMesh.YStart);
                vertex2 = new Vector3(newXPosition, newYPosition);
            }

            terrainMesh.MoveMesh(vertex1, vertex2);
            _isSameHeight = !_isSameHeight;
        }
    }
}