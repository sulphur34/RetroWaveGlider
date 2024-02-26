using UnityEngine;

public class ScenarioHandler : MonoBehaviour
{
    [SerializeField] private Scenario[] _scenarios;
    private TerrainMesh _terrainMeshLow;
    private TerrainMesh _terrainMeshUp;
    private CameraData _cameraData;

    private int _currentScenarioIndex = 0;
    private float _swichDelay = 10;
    private float _timePassed = 0;

    public void Initialize(TerrainMesh terrainMeshLow, TerrainMesh terrainMeshUp, CameraData cameraData)
    {
        _cameraData = cameraData;
        _terrainMeshLow = terrainMeshLow;
        _terrainMeshUp = terrainMeshUp;

        foreach (var scenario in _scenarios)
        {
            scenario.Initialize(_terrainMeshLow, _terrainMeshUp, _cameraData);
        }

        _scenarios[_currentScenarioIndex].Activate();
    }

    private void Update()
    {
        _timePassed += Time.deltaTime;
        if (_swichDelay <= _timePassed)
        {
            _timePassed = 0;    
            _scenarios[_currentScenarioIndex].Deactivate();
            _currentScenarioIndex = _currentScenarioIndex >= _scenarios.Length - 1 ? 0 : ++_currentScenarioIndex;
            _scenarios[_currentScenarioIndex].Activate();
        }
    }

}
