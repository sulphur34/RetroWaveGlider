using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    [SerializeField] private ColorSheme[] _colorSchemes;

    private Dictionary<string, ColorData> _colorsData;
    private Coroutine _coroutine;
    private int _schemeIndex;
    private int _nextSchemeIndex;

    public IColorData GetColorData(string name)
    {
        return _colorsData[name];
    }

    public void Initialize(int schemeIndex)
    {
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
        float step = 0.1f;

        while (hueAdditionValue < hueMaxValue)
        {
            Debug.Log("Coroutine in");
            hueAdditionValue += step * Time.deltaTime;

            foreach (ColorData colorData in _colorsData.Values)
            {
                colorData.AddHue(hueAdditionValue);
            }

            yield return new WaitForSeconds(0.01f);
        }

        Debug.Log("Coroutine out");
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
        float step = 0.1f;

        while (interpolationValue < maxInterpolationValue)
        {
            interpolationValue += step;

            foreach (string key in _colorsData.Keys)
            {
                ColorData colorData = _colorsData[key];
                Color targetColor = _colorSchemes[_nextSchemeIndex].Colors[key];
                colorData.InterpolateColor(targetColor, interpolationValue);
            }

            yield return new WaitForSeconds(0.1f);
        }

        IncreaseIndex();
        LoopHue();
    }

    private void SetIndex(int index)
    {
        Debug.Log(index);
        _schemeIndex = index;
        _nextSchemeIndex = _nextSchemeIndex < _colorSchemes.Length - 1 ? index += 1 : 0;
    }

    private void IncreaseIndex()
    {
        int index = _schemeIndex < _colorSchemes.Length - 1 ? _schemeIndex += 1 : 0;
        SetIndex(index);
    }
}
