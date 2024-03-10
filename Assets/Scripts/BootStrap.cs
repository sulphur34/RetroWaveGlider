using CollectiblesSystem;
using ColorSystem;
using ColorSystem.ColorTracker;
using TerrainSystem;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [SerializeField] private ColorHandler _colorHandler;
    [SerializeField] private CameraData _cameraData;
    [SerializeField] private ColorTracker[] _colorTrackers;
    [SerializeField] private CaveBuilder[] _caveBuilders;
    [SerializeField] private CollectibleSpawner _collectibleSpawner;

    private void Awake()
    {
        _cameraData.Initialize();
        _colorHandler.Initialize(0);

        foreach (ColorTracker tracker in _colorTrackers)
            tracker.Initialize();
        
        foreach (CaveBuilder caveBuilder in _caveBuilders)
            caveBuilder.Initialize<CanyonPattern>();
        
        _collectibleSpawner.Initialize();
    }
}