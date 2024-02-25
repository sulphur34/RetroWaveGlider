using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [SerializeField] private ColorHandler _colorHandler;
    [SerializeField] private CameraData _cameraData;
    [SerializeField] private ColorTracker[] _colorTrackers;

    private void Awake()
    {        
        _cameraData.Initialize();
        _colorHandler.Initialize(0);

        foreach (ColorTracker tracker in _colorTrackers)
            tracker.Initialize();
    }
}
