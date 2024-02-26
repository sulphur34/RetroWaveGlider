using UnityEngine;

public class StalagmiteScenario : Scenario
{
    private bool _isSameHeight = false;

    protected override void GenerateTerrain(TerrainMesh terrainMesh, float minConstrain, float maxConstrain)
    {
        Vector3 lastVertice = terrainMesh.LastVertice;
        Vector3 verticie1;
        Vector3 verticie2;
        float offsetValue = 2f;
        float newXPosition = lastVertice.x + terrainMesh.XDelta;

        if (_isSameHeight)
        {
            verticie1 = new Vector3(newXPosition, terrainMesh.YStart);
            verticie2 = new Vector3(newXPosition, lastVertice.y);
        }
        else
        {
            float newYPosition = lastVertice.y + Random.Range(-offsetValue, offsetValue);
            newYPosition = Mathf.Clamp(newYPosition, minConstrain, maxConstrain);
            verticie1 = new Vector3(newXPosition, terrainMesh.YStart);
            verticie2 = new Vector3(newXPosition, newYPosition);
        }

        terrainMesh.MoveMesh(verticie1, verticie2);
        _isSameHeight = _isSameHeight ? false : true;
    }
}
