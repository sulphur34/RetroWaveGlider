using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [SerializeField] private ColorHandler _colorHandler;
    [SerializeField] private CameraData _cameraData;
    [SerializeField] private ColorTracker[] _colorTrackers;
    [SerializeField] private ScenarioHandler _scenarioHandler;
    [SerializeField] private ScenarioHandler _scenarioHandler2;
    [SerializeField] private TerrainMesh _terrainMeshLow;
    [SerializeField] private TerrainMesh _terrainMeshUp; 

    private void Awake()
    {        
        _cameraData.Initialize();
        _colorHandler.Initialize(0);

        foreach (ColorTracker tracker in _colorTrackers)
            tracker.Initialize();

        _scenarioHandler.Initialize(_terrainMeshLow, _cameraData);
        _scenarioHandler2.Initialize(_terrainMeshUp, _cameraData);
    }
}
