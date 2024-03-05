using UnityEngine;

namespace TerrainSystem
{
    public class GapGenerator
    {
        private readonly float _minHeight = 3;
        private readonly float _offsetMaxStep = 2;
        private float _screenHeight;
        private float _screenBorderWidth;
        private float _maxHeight;
        private GapData _lastGapData;

        public GapGenerator(float screenHeight)
        {
            _screenHeight = screenHeight;
            _screenBorderWidth = _screenHeight * 0.9f;
            _maxHeight = _screenBorderWidth;
        }

        public GapData GetGapData(float _difficultyFactor)
        {
            float height = GetRandomHeight(_difficultyFactor);
            float offset = GetRandomOffset(height);
            Debug.Log(height + " - " + offset);
            float upperMinLimit = offset + height / 2;
            float upperMaxLimit = upperMinLimit + 1f;
            float lowerMaxLimit = offset - height / 2;
            float lowerMinLimit = lowerMaxLimit - 1f;
            _lastGapData = new GapData(upperMinLimit, upperMaxLimit, lowerMinLimit, lowerMaxLimit);
            return _lastGapData;
        }

        private float GetRandomHeight(float difficultyFactor)
        {
            float maxValue = Mathf.Clamp((_maxHeight - 1) / difficultyFactor, _minHeight, _screenBorderWidth);
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
