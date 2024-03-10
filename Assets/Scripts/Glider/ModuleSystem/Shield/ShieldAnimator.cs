using UnityEngine;

namespace Glider.ModuleSystem.Shield
{
    [RequireComponent(typeof(Shield))]
    public class ShieldAnimator : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _activationParticle;
        [SerializeField] private ParticleSystem _timeDeactivationParticle;
        [SerializeField] private ParticleSystem _collisionParticle;

        private Shield _shield;

        private void Awake()
        {
            _shield = GetComponent<Shield>();
            _shield.Activated += OnActivation;
            _shield.Collided += OnCollision;
            _shield.Disabled += OnDisable;
        }

        private void OnActivation()
        {
            ActivateParticle(_activationParticle);
        }

        private void OnCollision()
        {
            ActivateParticle(_collisionParticle);
        }

        private void OnDisable()
        {
            ActivateParticle(_timeDeactivationParticle);
        }

        private void ActivateParticle(ParticleSystem particleSystem)
        {
            Instantiate(particleSystem, this.transform);
        }
    }
}