using UnityEngine;

public class StalagmiteScenario : MonoBehaviour
{
    [SerializeField] private TerrainMesh _terrainMeshLow;
    [SerializeField] private TerrainMesh _terrainMeshUp;
    [SerializeField] private CameraData _cameraData;

    private float _xDelta;
    private float _yDelta;
    private float _minGap;
    private bool _isSameHeight;

    private void Start()
    {
        _isSameHeight = false;
        _minGap = 2;
        _xDelta = 0.25f;
        int blockSize = Mathf.RoundToInt(_cameraData.Width / _xDelta) + 7;
        _yDelta = 0.25f;
        _terrainMeshLow.Initialize(_cameraData.LeftBorder - 1, _cameraData.LowerBorder, _xDelta, _yDelta, blockSize);
        _terrainMeshUp.Initialize(_cameraData.LeftBorder - 1, _cameraData.UpperBorder, _xDelta, -_yDelta, blockSize);
    }

    private void Update()
    {
        if (_cameraData.LeftBorder - 1 > _terrainMeshLow.XStart)
        {
            GenerateTerrain(_terrainMeshLow, _cameraData.LowerBorder, _terrainMeshLow.YStart + _yDelta, -_minGap/2);
            GenerateTerrain(_terrainMeshUp, _cameraData.UpperBorder, _minGap / 2, _terrainMeshUp.YStart - _yDelta);
            _isSameHeight = _isSameHeight ? false : true;
        }
    }

    private void GenerateTerrain(TerrainMesh terrainMesh, float ancorPosition, float minConstrain, float maxConstrain)
    {
        Vector3 lastVertice = terrainMesh.LastVertice;
        Vector3 verticie1;
        Vector3 verticie2;
        float offsetValue = 1f;
        float newXPosition = lastVertice.x + _xDelta;

        if (_isSameHeight)
        {
            verticie1 = new Vector3(newXPosition, ancorPosition);
            verticie2 = new Vector3(newXPosition, lastVertice.y);
        }
        else
        {
            float newYPosition = lastVertice.y + Random.Range(-offsetValue, offsetValue);
            newYPosition = Mathf.Clamp(newYPosition, minConstrain, maxConstrain);
            verticie1 = new Vector3(newXPosition, ancorPosition);
            verticie2 = new Vector3(newXPosition, newYPosition);
        }
        
        terrainMesh.MoveMesh(verticie1, verticie2);
    }
}
