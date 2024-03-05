using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorSystem
{
    public class ColorHandler : MonoBehaviour
    {
        [SerializeField] private ColorSheme[] _colorSchemes;
        [SerializeField] private float _hueChangeStep = 0.1f;
        [SerializeField] private float _hueChangeDelay = 0.001f;
        [SerializeField] private float _colorTransitStep = 0.01f;
        [SerializeField] private float _colorTransitDelay = 0.1f;

        private Dictionary<string, ColorData> _colorsData;
        private Coroutine _coroutine;
        private int _schemeIndex;
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
            SetIndex(schemeIndex);
            _colorsData = new Dictionary<string, ColorData>();

            foreach (ColorSheme colorScheme in _colorSchemes)
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

            IncreaseIndex();
            LoopHue();
        }

        private void SetIndex(int index)
        {
            _schemeIndex = index;
            _nextSchemeIndex = _nextSchemeIndex < _colorSchemes.Length - 1 ? index += 1 : 0;
        }

        private void IncreaseIndex()
        {
            int index = _schemeIndex < _colorSchemes.Length - 1 ? _schemeIndex += 1 : 0;
            SetIndex(index);
        }
    }
}