using Assets.Scripts.CollectiblesSystem;
using Assets.Scripts.ColorSystem;
using Assets.Scripts.ColorSystem.ColorTracker;
using Assets.Scripts.TerrainSystem;
using UnityEngine;

namespace Assets.Scripts
{
    public class BootStrap : MonoBehaviour
    {
        [SerializeField] private ColorHandler _colorHandler;
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private ColorTracker[] _colorTrackers;
        [SerializeField] private CaveBuilder _caveBuilder;
        [SerializeField] private CaveBuilder _backgroundCaveBuilder;
        [SerializeField] private CollectibleSpawner _collectibleSpawner;

        private void Awake()
        {
            _cameraData.Initialize();
            _colorHandler.Initialize(0);

            foreach (ColorTracker tracker in _colorTrackers)
                tracker.Initialize();

            _caveBuilder.Initialize();
            _backgroundCaveBuilder.Initialize();
            _collectibleSpawner.Initialize();
        }
    }
}