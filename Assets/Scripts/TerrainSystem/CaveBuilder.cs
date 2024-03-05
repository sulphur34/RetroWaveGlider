using UnityEngine;

namespace TerrainSystem
{
    public class CaveBuilder : MonoBehaviour
    {
        [SerializeField] private ScenarioHandler _lowScenarioHandler;
        [SerializeField] private ScenarioHandler _upperScenarioHandler;
        [SerializeField] private TerrainMesh _terrainMeshHigh;
        [SerializeField] private TerrainMesh _terrainMeshLow;
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private int _prewarmValue;
        [SerializeField] private float _xTerrainDelta = 0.25f;
        [SerializeField] private float _yTerrainDelta = 0.25f;
        [SerializeField] private float _switchDelay = 4;

        private GapGenerator _gapGenerator;
        private Coroutine _coroutine;

        private float _timePassed = 0;
        private float _difficultyFactor = 1;

        public Vector2 GapPositionY => new Vector2(_terrainMeshHigh.LastVertex.y, _terrainMeshLow.LastVertex.y);
        public float XEnd => _terrainMeshLow.LastVertex.x;

        private void Update()
        {
            _timePassed += Time.deltaTime;

            if (_switchDelay <= _timePassed)
            {
                GapData gapData = _gapGenerator.GetGapData(3);
                _lowScenarioHandler.Refresh(gapData.LowerMaxLimit, gapData.LowerMinLimit);
                _upperScenarioHandler.Refresh(gapData.UpperMaxLimit, gapData.UpperMinLimit);
                _timePassed = 0;
            }
        }

        public void Initialize()
        {
            _prewarmValue = Mathf.RoundToInt(_cameraData.Width / _xTerrainDelta) * 2;
            _gapGenerator = new GapGenerator(_cameraData.Height);
            SetTerrains();
            SetScenarioHandlers();
            Activate();
        }

        public void Activate()
        {
            GapData gapData = _gapGenerator.GetGapData(_difficultyFactor);
            _lowScenarioHandler.Activate(gapData.LowerMaxLimit, gapData.LowerMinLimit);
            _upperScenarioHandler.Activate(gapData.UpperMaxLimit, gapData.UpperMinLimit);
        }

        public void Deactivate()
        {
            _lowScenarioHandler.Deactivate();
            _upperScenarioHandler.Deactivate();
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

        private void SetScenarioHandlers()
        {
            _upperScenarioHandler.Initialize(_terrainMeshHigh, _cameraData);
            _lowScenarioHandler.Initialize(_terrainMeshLow, _cameraData);
        }
    }
}
