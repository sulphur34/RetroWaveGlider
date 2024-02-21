using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [SerializeField] private ColorHandler _colorHandler;
    [SerializeField] private CameraData _cameraData;
    [SerializeField] private PlayerTracker _playerTracker;
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private GliderFabric _gliderFabric;
    [SerializeField] private ColorTrackerUI _background;

    private void Awake()
    {
        _cameraData.Initialize();
        _colorHandler.Initialize(0);
        _obstacleSpawner.Initialize(_cameraData);
        _gliderFabric.Initialize(_colorHandler);
        Glider glider = _gliderFabric.Build();
        _playerTracker.Initialize(glider);
        _background.Initialize(_colorHandler.GetColorData(ColorNames.BackGround));
    }
}
