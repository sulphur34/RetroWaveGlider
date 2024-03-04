using System.Collections;
using UnityEngine;

namespace Assets.Scripts.TerrainSystem
{
    public class ScenarioHandler : MonoBehaviour
    {
        [SerializeField] private float _switchDelay;

        private Scenario[] _scenarios;
        private TerrainMesh _terrainMesh;
        private CameraData _cameraData;
        private Coroutine _coroutine;
        private int _currentScenarioIndex;
        private float _timePassed;
        private float _lowerLimit;
        private float _upperLimit;

        public void Initialize(TerrainMesh terrainMesh, CameraData cameraData)
        {
            _cameraData = cameraData;
            _terrainMesh = terrainMesh;
            _timePassed = _switchDelay;
            SetScenarios();
        }

        public void Activate(float upperLimit, float lowerLimit)
        {
            SetLimits(lowerLimit, upperLimit);
            _coroutine = StartCoroutine(GeneratingTerrain());
        }

        public void Deactivate()
        {
            StopCoroutine(_coroutine);
        }

        public void Refresh(float upperLimit, float lowerLimit)
        {
            Deactivate();
            Activate(upperLimit, lowerLimit);
        }

        public void SetLimits(float lowerLimit, float upperLimit)
        {
            _lowerLimit = lowerLimit;
            _upperLimit = upperLimit;
        }

        private IEnumerator GeneratingTerrain()
        {
            bool isContinue = true;

            while (isContinue)
            {
                _timePassed += Time.deltaTime;

                if (_switchDelay <= _timePassed)
                {
                    _timePassed = 0;
                    _scenarios[_currentScenarioIndex].Deactivate();
                    _currentScenarioIndex = _currentScenarioIndex >= _scenarios.Length - 1 ? 0 : ++_currentScenarioIndex;
                    _scenarios[_currentScenarioIndex].Activate(_lowerLimit, _upperLimit);
                }

                yield return null;
            }
        }

        private void SetScenarios()
        {
            _scenarios = GetComponentsInChildren<Scenario>();

            foreach (var scenario in _scenarios)
            {
                scenario.Initialize(_terrainMesh, _cameraData);
            }
        }
    }
}