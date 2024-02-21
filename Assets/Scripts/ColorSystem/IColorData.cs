using System;
using UnityEngine;

public interface IColorData
{
    public Color Color { get; }

    public event Action<Color> ColorChanged;
}
