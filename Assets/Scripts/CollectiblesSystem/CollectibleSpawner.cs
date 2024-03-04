using System.Collections;
using Assets.Scripts.TerrainSystem;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.CollectiblesSystem
{
    public class CollectibleSpawner : MonoBehaviour, ISpawner
    {
        [SerializeField] private Collectible _collectiblePrefab;
        [SerializeField] private CaveBuilder _caveBuilder;
        [SerializeField] private int _startAmount = 5;
        [SerializeField] private float _spawnDelay = 5;

        private ObjectPool<Collectible> _objectPool;
        private WaitForSeconds _waitForSeconds;
        private Coroutine _coroutine;

        public void Initialize()
        {
            _objectPool = new ObjectPool<Collectible>();
            _objectPool.Initialize(_collectiblePrefab, _startAmount);
            _waitForSeconds = new WaitForSeconds(_spawnDelay);
            Activate();
        }

        public void Activate()
        {
            _coroutine = StartCoroutine(Spawning());
        }

        public void Deactivate()
        {
            StopCoroutine(_coroutine);
        }

        private IEnumerator Spawning()
        {
            bool isContinue = true;

            while (isContinue)
            {
                Spawn();
                yield return _waitForSeconds;
            }
        }

        public void Spawn()
        {
            Vector3 position = GetPosition();
            _objectPool.Get().transform.position = position;
        }

        private Vector3 GetPosition()
        {
            float yPosition = (_caveBuilder.GapPositionY.x + _caveBuilder.GapPositionY.y) / 2;
            return new Vector3(_caveBuilder.XEnd, yPosition);
        }
    }
}
