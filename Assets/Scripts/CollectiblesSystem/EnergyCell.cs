using Assets.Scripts.CollectiblesSystem;
using Assets.Scripts.Glider;
using UnityEngine;

public class EnergyCell : Collectible
{
    [SerializeField] private ParticleSystem _onCollectParticlePrefab;
    protected override void OnCollision(Glider glider)
    {
        Destroy(gameObject);
    }
}
