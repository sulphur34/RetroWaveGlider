using System.Collections;
using UnityEngine;

namespace TerrainSystem
{
    public class CaveBuilder : MonoBehaviour
    {
        [SerializeField] private TerrainMesh _terrainMeshHigh;
        [SerializeField] private TerrainMesh _terrainMeshLow;
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private int _prewarmValue;
        [SerializeField] private float _xTerrainDelta = 0.25f;
        [SerializeField] private float _yTerrainDelta = 0.25f;
        [SerializeField] private float _difficultyFactor = 1;
        [SerializeField] private float _minGapHeight = 2;

        private GapGenerator _gapGenerator;
        private Coroutine _coroutine;
        private GapData _gapData;
        private Pattern _patternLow;
        private Pattern _patternHigh;

        public Vector2 GapPositionY => new Vector2(_terrainMeshHigh.LastVertex.y, _terrainMeshLow.LastVertex.y);
        public float XEnd => _terrainMeshLow.LastVertex.x;

        public void Initialize<T>() where T : Pattern, new()
        {
            _patternLow = new T();
            _patternHigh = new T();
            _prewarmValue = Mathf.RoundToInt(_cameraData.Width / _xTerrainDelta) * 2;
            _gapGenerator = new GapGenerator(_cameraData.Height);
            _gapData = _gapGenerator.GetGapData(_minGapHeight, _difficultyFactor);
            SetTerrains();
            Activate();
        }

        public void Activate()
        {
            _coroutine = StartCoroutine(Building());
        }

        public void Deactivate()
        {
            StopCoroutine(_coroutine);
        }

        private void SetTerrains()
        {
            _terrainMeshHigh.Initialize(new TerrainData(
                _cameraData.LeftBorder - 1,
                _cameraData.UpperBorder,
                _xTerrainDelta,
                -_yTerrainDelta,
                _prewarmValue));
            _terrainMeshLow.Initialize(new TerrainData(
                _cameraData.LeftBorder - 1,
                _cameraData.LowerBorder,
                _xTerrainDelta,
                _yTerrainDelta,
                _prewarmValue));
        }

        private IEnumerator Building()
        {
            bool isContinue = true;

            while (isContinue)
            {
                if (_cameraData.LeftBorder - 1 > _terrainMeshHigh.XStart)
                {
                    while (_cameraData.RightBorder + 2 >= _terrainMeshHigh.LastVertex.x)
                    {
                        _patternHigh.GenerateTerrain(_terrainMeshHigh, _gapData.UpperMinLimit, _gapData.UpperMaxLimit);
                        _patternLow.GenerateTerrain(_terrainMeshLow, _gapData.LowerMinLimit, _gapData.LowerMaxLimit);
                    }
                }

                yield return null;
            }
        }
    }
}