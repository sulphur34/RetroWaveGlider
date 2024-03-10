using Glider;
using Glider.ModuleSystem;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private GliderConfig[] _glidersData;
    [SerializeField] private ModuleConfig[] _moduleData;

    public override void InstallBindings()
    {
    }

    private void BindGlider()
    {
    }
}