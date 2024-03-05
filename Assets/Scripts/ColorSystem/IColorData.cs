using System;
using UnityEngine;

namespace ColorSystem
{
    public interface IColorData
    {
        public Color Color { get; }

        public event Action<Color> ColorChanged;
    }
}