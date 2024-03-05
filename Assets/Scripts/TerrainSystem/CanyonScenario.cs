using UnityEngine;

namespace TerrainSystem
{
    public class CanyonScenario : Scenario
    {
        private int _patternRepeatValue = 0;
        private int _offsetValue = 0;
        protected override void GenerateTerrain(TerrainMesh terrainMesh, float minConstrain, float maxConstrain)
        {
            Vector3 lastVertex = terrainMesh.LastVertex;

            if (_patternRepeatValue <= 0)
            {
                _offsetValue = Random.Range(-1, 2);
                _patternRepeatValue = Random.Range(1, 5);
            }

            _patternRepeatValue--;
            float newXPosition = lastVertex.x + terrainMesh.XDelta;
            float newYPosition = lastVertex.y + terrainMesh.XDelta * _offsetValue;
            newYPosition = Mathf.Clamp(newYPosition, minConstrain, maxConstrain);
            Vector3 vertex1 = new Vector3(newXPosition, terrainMesh.YStart);
            Vector3 vertex2 = new Vector3(newXPosition, newYPosition);
            terrainMesh.MoveMesh(vertex1, vertex2);
        }
    }
}
