using UnityEngine;

namespace TerrainSystem
{
    public class GapGenerator
    {
        private readonly float _offsetMaxStep = 1;
        private readonly float _maxHeight;
        
        private GapData _lastGapData;
        private float _minHeight;

        public GapGenerator(float screenHeight)
        {
            _maxHeight = screenHeight * 0.95f;
        }

        public GapData GetGapData(float minHeight, float difficultyFactor)
        {
            _minHeight = minHeight;
            float height = GetRandomHeight(difficultyFactor);
            float offset = GetRandomOffset(height);
            float upperMinLimit = offset + height / 2;
            float upperMaxLimit = _maxHeight / 2;
            float lowerMinLimit = -_maxHeight / 2;
            float lowerMaxLimit = offset - height / 2;
            _lastGapData = new GapData(upperMinLimit, upperMaxLimit, lowerMinLimit, lowerMaxLimit);
            return _lastGapData;
        }

        private float GetRandomHeight(float difficultyFactor)
        {
            float maxValue = Random.Range(_minHeight, _maxHeight / difficultyFactor);
            return maxValue;
        }

        private float GetRandomOffset(float height)
        {
            float maxOffset = _maxHeight / 2 - height / 2;
            float minOffset = -maxOffset;
            float offset = Mathf.Clamp(Random.Range(-_offsetMaxStep, _offsetMaxStep), minOffset, maxOffset);
            return offset;
        }
    }
}
