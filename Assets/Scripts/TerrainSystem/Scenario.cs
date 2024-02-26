using System.Collections;
using UnityEngine;

public abstract class Scenario : MonoBehaviour
{
    private TerrainMesh _terrainMeshLow;
    private TerrainMesh _terrainMeshUp;
    private CameraData _cameraData;
    protected float _xDelta;
    protected float _yDelta;
    private float _minGap;
    private Coroutine _coroutine;

    public virtual void Initialize(TerrainMesh terrainMeshLow, TerrainMesh terrainMeshUp, CameraData cameraData)
    {
        _minGap = 2;
        _xDelta = 0.25f;
        _cameraData = cameraData;
        int blockSize = Mathf.RoundToInt(_cameraData.Width / _xDelta) + 7;
        _yDelta = 0.25f;
        _terrainMeshLow = terrainMeshLow;
        _terrainMeshUp = terrainMeshUp;
        _terrainMeshLow.Initialize(_cameraData.LeftBorder - 1, _cameraData.LowerBorder, _xDelta, _yDelta, blockSize);
        _terrainMeshUp.Initialize(_cameraData.LeftBorder - 1, _cameraData.UpperBorder, _xDelta, -_yDelta, blockSize);
    }

    public void Activate()
    {
        _coroutine = StartCoroutine(Generate());
    }

    public void Deactivate()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    protected virtual IEnumerator Generate()
    {
        bool isContinue = true;

        while (isContinue)
        {
            if (_cameraData.LeftBorder - 1 > _terrainMeshLow.XStart)
            {
                GenerateTerrains();
            }

            yield return null;
        }
    }

    protected virtual void GenerateTerrains()
    {
        GenerateTerrain(_terrainMeshLow, _cameraData.LowerBorder, _terrainMeshLow.YStart + _yDelta, -_minGap / 2);
        GenerateTerrain(_terrainMeshUp, _cameraData.UpperBorder, _minGap / 2, _terrainMeshUp.YStart - _yDelta);
    }

    protected abstract void GenerateTerrain(TerrainMesh terrainMesh, float ancorPosition, float minConstrain, float maxConstrain);
}
