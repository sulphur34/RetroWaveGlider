using System.Collections;
using UnityEngine;

namespace Assets.Scripts.TerrainSystem
{
    public abstract class Scenario : MonoBehaviour
    {
        private TerrainMesh _terrainMesh;
        private CameraData _cameraData;
        private Coroutine _coroutine;
        private float _lowerLimit;
        private float _upperLimit;

        public virtual void Initialize(TerrainMesh terrainMesh, CameraData cameraData)
        {
            _cameraData = cameraData;
            _terrainMesh = terrainMesh;
        }

        public void Activate(float lowerLimit, float upperLimit)
        {
            _lowerLimit = lowerLimit;
            _upperLimit = upperLimit;
            _coroutine = StartCoroutine(Generate());
        }

        public void Deactivate()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }

        protected virtual IEnumerator Generate()
        {
            bool isContinue = true;

            while (isContinue)
            {
                if (_cameraData.LeftBorder - 1 > _terrainMesh.XStart)
                {
                    GenerateTerrain(_terrainMesh, _lowerLimit, _upperLimit);
                }

                yield return null;
            }
        }

        protected abstract void GenerateTerrain(TerrainMesh terrainMesh, float lowerLimit, float upperLimit);
    }
}