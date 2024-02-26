using UnityEngine;

public class ScenarioHandler : MonoBehaviour
{
    [SerializeField] private bool isGround;
    [SerializeField] private float _swichDelay;

    private Scenario[] _scenarios;
    private TerrainMesh _terrainMesh;
    private ScenarioData _scenarioData;
    private CameraData _cameraData;
    private TerrainData _terrainData;
    private int _currentScenarioIndex = 0;
    private float _timePassed = 0;
    private float _lowerLimit;
    private float _upperLimit;

    public void Initialize(TerrainMesh terrainMesh, CameraData cameraData)
    {
        _cameraData = cameraData;
        _terrainMesh = terrainMesh;
        SetTerrainMesh();
        _scenarios = GetComponentsInChildren<Scenario>();

        foreach (var scenario in _scenarios)
        {
            scenario.Initialize(_terrainMesh, _cameraData);
        }

        SetGap(3f, -2);
        _scenarios[_currentScenarioIndex].Activate(_lowerLimit, _upperLimit);
    }

    private void Update()
    {
        _timePassed += Time.deltaTime;
        if (_swichDelay <= _timePassed)
        {
            _timePassed = 0;    
            _scenarios[_currentScenarioIndex].Deactivate();
            _currentScenarioIndex = _currentScenarioIndex >= _scenarios.Length - 1 ? 0 : ++_currentScenarioIndex;
            SetGap(3f, -2);
            _scenarios[_currentScenarioIndex].Activate(_lowerLimit, _upperLimit);
        }
    }

    private void SetTerrainMesh()
    {
        float yStart;
        float xDelta = 0.25f;
        float yDelta = 0.25f;
        int prewarmQuadsAmount = 7;
        int xSize = Mathf.CeilToInt(_cameraData.Width / xDelta) + prewarmQuadsAmount;

        if (isGround)
            yStart = _cameraData.LowerBorder;
        else
            yStart = _cameraData.UpperBorder;

        _terrainData = new TerrainData(_cameraData.LeftBorder - 1, yStart, xDelta, yDelta, xSize);
        _terrainMesh.Initialize(_terrainData);
    }

    private void SetGap(float gapHeight, float gapOffset)
    {
        if (isGround)
        {
            _upperLimit = gapOffset - gapHeight / 2;
            _lowerLimit = _terrainData.YStart + _terrainData.YDelta;
        }
        else
        {
            _upperLimit = _terrainData.YStart - _terrainData.YDelta; 
            _lowerLimit = gapOffset + gapHeight / 2;
        }
    }
}
