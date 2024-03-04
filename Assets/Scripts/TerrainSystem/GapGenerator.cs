using UnityEngine;

namespace Assets.Scripts.TerrainSystem
{
    public class GapGenerator
    {
        private float _screenHeight;
        private float _screenBorderWith;
        private float _maxHeight;
        private float _minHeight;

        public GapGenerator(float screenHeight)
        {
            _screenHeight = screenHeight;
            _screenBorderWith = _screenHeight * 0.9f;
            _maxHeight = _screenBorderWith;
            _minHeight = 7;
        }

        public GapData GetGapData(float _difficultyFactor)
        {
            float height = GetRandomHeight(_difficultyFactor);
            float offset = GetRandomOffset(height);
            float upperMinLimit = offset + height / 2;
            float upperMaxLimit = _screenBorderWith / 2;
            float lowerMinLimit = -_screenBorderWith / 2;
            float lowerMaxLimit = offset - height / 2;
            return new GapData(upperMinLimit, upperMaxLimit, lowerMinLimit, lowerMaxLimit);
        }

        private float GetRandomHeight(float difficultyFactor)
        {
            float maxValue = (_maxHeight - 1) / difficultyFactor;
            return maxValue;
        }

        private float GetRandomOffset(float height)
        {
            float maxOffset = _maxHeight / 2 - height / 2;
            float minOffset = -maxOffset;
            return Random.Range(minOffset, maxOffset);
        }
    }
}
