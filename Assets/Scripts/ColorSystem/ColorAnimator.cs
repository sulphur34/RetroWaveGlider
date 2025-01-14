using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ColorSystem
{
    public class ColorAnimator : MonoBehaviour
    {
        private ColorAnimatorConfig _config;
        private List<ColorData> _colorsData;
        private Coroutine _coroutine;
        private int _schemeIndex;
        private int _maxIndex;
        private WaitForSeconds _hueDelay;
        private WaitForSeconds _transitDelay;

        private int NextSchemeIndex => (++_schemeIndex % _maxIndex + _maxIndex) % _maxIndex;

        public IColorData GetColorData(ColorNames colorName)
        {
            return _colorsData[(int)colorName];
        }

        public void Initialize(ColorAnimatorConfig config, int schemeIndex = 0)
        {
            _config = config;
            _hueDelay = new WaitForSeconds(_config.HueChangeDelay);
            _transitDelay = new WaitForSeconds(_config.ColorTransitDelay);
            _maxIndex = _config.ColorSchemes.Length - 1;
            _schemeIndex = schemeIndex;
            _colorsData = _config.ColorSchemes[_schemeIndex].Colors.Select(color => new ColorData(color)).ToList();
            
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
                hueAdditionValue += _config.HueChangeStep * Time.deltaTime;

                foreach (ColorData colorData in _colorsData)
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
                interpolationValue += _config.ColorTransitStep;

                for (int i = 0; i < _colorsData.Count; i++)
                {
                    Color targetColor = _config.ColorSchemes[NextSchemeIndex].Colors[i];
                    _colorsData[i].InterpolateColor(targetColor, interpolationValue);
                }

                yield return _transitDelay;
            }

            _schemeIndex = NextSchemeIndex;
            LoopHue();
        }
    }
}