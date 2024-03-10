using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorSystem
{
    public class ColorHandler : MonoBehaviour
    {
        [SerializeField] private ColorConfig[] _colorSchemes;
        [SerializeField] private float _hueChangeStep = 0.1f;
        [SerializeField] private float _hueChangeDelay = 0.001f;
        [SerializeField] private float _colorTransitStep = 0.01f;
        [SerializeField] private float _colorTransitDelay = 0.1f;

        private Dictionary<string, ColorData> _colorsData;
        private Coroutine _coroutine;
        private int _schemeIndex;
        private int _maxIndex;
        private int _nextSchemeIndex;
        private WaitForSeconds _hueDelay;
        private WaitForSeconds _transitDelay;

        public IColorData GetColorData(string name)
        {
            return _colorsData[name];
        }

        public void Initialize(int schemeIndex)
        {
            _hueDelay = new WaitForSeconds(_hueChangeDelay);
            _transitDelay = new WaitForSeconds(_colorTransitDelay);
            _maxIndex = _colorSchemes.Length - 1;
            _schemeIndex = (schemeIndex % _maxIndex + _maxIndex) % _maxIndex;
            _colorsData = new Dictionary<string, ColorData>();

            foreach (ColorConfig colorScheme in _colorSchemes)
                colorScheme.Initialize();

            foreach (var keyValuePair in _colorSchemes[schemeIndex].Colors)
            {
                ColorData colorData = new ColorData(keyValuePair.Value);
                _colorsData.Add(keyValuePair.Key, colorData);
            }

            LoopHue();
        }

        private void LoopHue()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(AnimateHue());
        }

        private IEnumerator AnimateHue()
        {
            float hueAdditionValue = 0;
            float hueMaxValue = 1;

            while (hueAdditionValue < hueMaxValue)
            {
                hueAdditionValue += _hueChangeStep * Time.deltaTime;

                foreach (ColorData colorData in _colorsData.Values)
                {
                    colorData.AddHue(hueAdditionValue);
                }

                yield return _hueDelay;
            }

            Transit();
        }

        private void Transit()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(AnimateTransition());
        }

        private IEnumerator AnimateTransition()
        {
            float interpolationValue = 0;
            float maxInterpolationValue = 1;

            while (interpolationValue < maxInterpolationValue)
            {
                interpolationValue += _colorTransitStep;

                foreach (string key in _colorsData.Keys)
                {
                    ColorData colorData = _colorsData[key];
                    Color targetColor = _colorSchemes[_nextSchemeIndex].Colors[key];
                    colorData.InterpolateColor(targetColor, interpolationValue);
                }

                yield return _transitDelay;
            }

            _schemeIndex = (++_schemeIndex % _maxIndex + _maxIndex) % _maxIndex;
            LoopHue();
        }
    }
}