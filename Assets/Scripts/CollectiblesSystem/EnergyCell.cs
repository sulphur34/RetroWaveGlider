using UnityEngine;

namespace CollectiblesSystem
{
    public class EnergyCell : Collectible
    {
        [SerializeField] private ParticleSystem _onCollectParticlePrefab;
        protected override void OnCollision(Glider.Glider glider)
        {
            Instantiate(_onCollectParticlePrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
