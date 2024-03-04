using System;
using UnityEngine;

namespace Assets.Scripts.ColorSystem
{
    public interface IColorData
    {
        public Color Color { get; }

        public event Action<Color> ColorChanged;
    }
}