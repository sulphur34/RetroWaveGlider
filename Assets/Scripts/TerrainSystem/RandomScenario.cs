using UnityEngine;

public class RandomScenario : Scenario
{
    protected override void GenerateTerrain(TerrainMesh terrainMesh, float minConstrain, float maxConstrain)
    {
        Vector3 lastVertice = terrainMesh.LastVertice;
        float offsetValue = Random.Range(0.1f, 0.5f);
        float newXPosition = lastVertice.x + terrainMesh.XDelta;
        float newYPosition = lastVertice.y + Random.Range(-offsetValue, offsetValue);
        newYPosition = Mathf.Clamp(newYPosition, minConstrain, maxConstrain);
        Vector3 verticie1 = new Vector3(newXPosition, terrainMesh.YStart);
        Vector3 verticie2 = new Vector3(newXPosition, newYPosition);
        terrainMesh.MoveMesh(verticie1, verticie2);
    }
}
