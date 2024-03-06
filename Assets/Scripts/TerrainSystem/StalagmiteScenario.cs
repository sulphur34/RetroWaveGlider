using UnityEngine;

namespace TerrainSystem
{
    public class StalagmiteScenario : Scenario
    {
        private readonly float _minOffset = 0.25f;
        private readonly float _maxOffset = 1f;
        private bool _isSameHeight = false;
        
        public override void GenerateTerrain(TerrainMesh terrainMesh,float minConstrain, float maxConstrain)
        {
            Vector3 lastVertex = terrainMesh.LastVertex;
            Vector3 vertexLow;
            Vector3 vertexHigh;
            float offsetValue = Random.Range(_minOffset, _maxOffset);
            float newXPosition = lastVertex.x + terrainMesh.XDelta;

            if (_isSameHeight)
            {
                vertexLow = new Vector3(newXPosition, terrainMesh.YStart);
                vertexHigh = new Vector3(newXPosition, lastVertex.y);
            }
            else
            {
                float newYPosition = lastVertex.y + Random.Range(-offsetValue, offsetValue);
                newYPosition = Mathf.Clamp(newYPosition, minConstrain, maxConstrain);
                vertexLow = new Vector3(newXPosition, terrainMesh.YStart);
                vertexHigh = new Vector3(newXPosition, newYPosition);
            }

            terrainMesh.MoveMesh(vertexLow, vertexHigh);
            _isSameHeight = !_isSameHeight;
        }
    }
}