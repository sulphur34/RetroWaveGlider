using UnityEngine;

namespace Glider
{
    [CreateAssetMenu(menuName = "Glider Config", fileName = "Glider Config", order = 54)]
    public class GliderConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject GliderPrefab { get; private set; }
        [field: SerializeField] public ParticleSystem WingTrace { get; private set; }
        [field: SerializeField] public ParticleSystem EngineFire { get; private set; }
        
        [field: SerializeField] public Vector3 ShieldPosition { get; private set; }
        [field: SerializeField] public Vector3 ShootingPoint { get; private set; }
        [field: SerializeField] public Vector3 MagnetPosition { get; private set; }
        
        [field: SerializeField] public float LiftForce { get; private set; }
        [field: SerializeField] public float AccelerationForce { get; private set; }
        [field: SerializeField] public float TorqueForce { get; private set; }
        [field: SerializeField] public float Mass { get; private set; }
        [field: SerializeField] public float MaxSpeed { get; private set; }
        [field: SerializeField] public float EnergyPool { get; private set; }        
        
        [field: SerializeField] public string ModelName { get; private set; }
        [field: SerializeField] public string CompanyName { get; private set; }
        [field: SerializeField] public Sprite CompanyLogo { get; private set; }
    }
}
