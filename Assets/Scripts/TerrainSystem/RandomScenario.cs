using UnityEngine;

public class RandomScenario : Scenario
{
    protected override void GenerateTerrain(TerrainMesh terrainMesh, float ancorPosition, float minConstrain, float maxConstrain)
    {
        Vector3 lastVertice = terrainMesh.LastVertice;
        float offsetValue = 0.1f;
        float newXPosition = lastVertice.x + _xDelta;
        float newYPosition = lastVertice.y + Random.Range(-offsetValue, offsetValue);
        newYPosition = Mathf.Clamp(newYPosition, minConstrain, maxConstrain);
        Vector3 verticie1 = new Vector3(newXPosition, ancorPosition);
        Vector3 verticie2 = new Vector3(newXPosition, newYPosition);
        terrainMesh.MoveMesh(verticie1, verticie2);
    }
}
