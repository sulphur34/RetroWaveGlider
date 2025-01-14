using System;
using System.Collections;
using Enemies;
using Glider.EnergySystem;
using TerrainSystem;
using UnityEngine;

namespace Glider.ModuleSystem.Shield
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Shield : MonoBehaviour, IModule, IConsumer
    {
        private readonly float _disableCheckStep = 0.1f;
        
        private SpriteRenderer _spriteRenderer;
        private CircleCollider2D _circleCollider2D;
        private float _shieldDuration;
        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds;

        public event Action Activated;
        public event Action Collided;
        public event Action Disabled;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _circleCollider2D = GetComponent<CircleCollider2D>();
            _shieldDuration = 30;
            _waitForSeconds = new WaitForSeconds(_disableCheckStep);
            ConcumeValue = 1;
            Activate();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Enemy enemy) || collider.TryGetComponent(out TerrainMesh terrainMesh))
            {
                Collided?.Invoke();
                Deactivate();
            }
        }

        public void Initialize(SpriteRenderer spriteRenderer, CircleCollider2D circleCollider2D, float concumeValue, float shieldDuration)
        {
            _spriteRenderer = spriteRenderer;
            _circleCollider2D = circleCollider2D;
            Collider2D parentCollider = GetComponentInParent<Collider2D>();
            Physics2D.IgnoreCollision(_circleCollider2D, parentCollider);
            _shieldDuration = shieldDuration;
            _waitForSeconds = new WaitForSeconds(_disableCheckStep);
            ConcumeValue = concumeValue;
        }

        public float ConcumeValue { get; private set; }

        public void Activate()
        {
            Activated?.Invoke();
            _coroutine = StartCoroutine(DisablingWithDelay());
            SetState(true);
        }

        public void Deactivate()
        {
            StopCoroutine(_coroutine);
            SetState(false);
        }

        private void SetState(bool isActive)
        {
            _spriteRenderer.enabled = isActive;
            _circleCollider2D.enabled = isActive;
        }

        private IEnumerator DisablingWithDelay()
        {
            float timePassed = 0;

            while (timePassed < _shieldDuration)
            {
                timePassed += _disableCheckStep;
                yield return _waitForSeconds;
            }
            
            Disabled?.Invoke();
            Deactivate();
        }
    }
}