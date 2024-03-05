using System;
using UnityEngine;

namespace ColorSystem
{
    public class ColorData : IColorData
    {
        private float _delay;
        private Color _initialColor;

        public event Action<Color> ColorChanged;

        public Color Color { get; private set; }

        public ColorData(Color color)
        {
            Color = color;
            _initialColor = color;
        }

        public void InterpolateColor(Color targetColor, float interpolateValue)
        {
            Color startColor = Color;
            Color = Color.Lerp(startColor, targetColor, interpolateValue);
            ColorChanged?.Invoke(Color);

            if (Color == targetColor)
                _initialColor = Color;
        }

        public void AddHue(float hueChageValue)
        {
            float hue, saturation, brightness;
            Color.RGBToHSV(_initialColor, out hue, out saturation, out brightness);
            hue += hueChageValue;
            hue = hue > 1 ? hue - 1 : hue;
            Color = Color.HSVToRGB(hue, saturation, brightness);
            ColorChanged?.Invoke(Color);
        }
    }
}