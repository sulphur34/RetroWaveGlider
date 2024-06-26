using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Obstacle _obstaclePrefab;

    private ObjectPool<Obstacle> _objectPool;
    private CameraData _cameraData;
    private float _lastCameraPosition;

    private void Update()
    {
        if (_cameraData.RightBorder - _lastCameraPosition >= 0.15)
        {
            SpawnNextRow();
            _lastCameraPosition = _cameraData.RightBorder;
        }
    }

    public void Initialize(CameraData cameraData)
    {
        _objectPool = new ObjectPool<Obstacle>();
        _cameraData = cameraData;
        _objectPool.Initialize(_obstaclePrefab, 200);
        _lastCameraPosition = _cameraData.RightBorder;
    }

    private void SpawnNextRow()
    {
        Obstacle obstacle = _objectPool.Get();
        obstacle.transform.position = GetSpawnPosition(_cameraData.RightBorder, _cameraData.LowerBorder);
        
    }

    private Vector3 GetSpawnPosition(float positionX, float positionY)
    {
        return new Vector3(positionX, positionY, 0);
    }
}
