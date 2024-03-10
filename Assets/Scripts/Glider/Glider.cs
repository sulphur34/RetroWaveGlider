using ColorSystem.ColorTracker;
using Glider.EnergySystem;
using Glider.ModuleSystem;
using UnityEngine;

namespace Glider
{
    [RequireComponent(typeof(GliderMover))]
    [RequireComponent(typeof(Controls))]
    [RequireComponent(typeof(ColorTracker))]
    public class Glider : MonoBehaviour
    {
        private Energy _energy;
        private IModule[] _modules;
    }
}