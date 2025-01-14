using Glider;
using Glider.ModuleSystem;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private GliderConfig[] _gliderConfigs;
    [SerializeField] private ModuleConfig[] _moduleConfigs;
    
    public override void InstallBindings()
    {
        
    }

    private void BindGlider()
    {
    }
}