using UnityEngine;

namespace CollectiblesSystem
{
    public class EnergyCell : Collectible
    {
        [SerializeField] private ParticleSystem _onCollectParticlePrefab;
        protected override void OnCollision(Glider.Glider glider)
        {
            Destroy(gameObject);
        }
    }
}
