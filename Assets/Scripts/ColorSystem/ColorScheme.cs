using System.Collections.Generic;
using UnityEngine;

namespace ColorSystem
{
    [CreateAssetMenu(menuName = "Color Scheme", fileName = "Color Scheme", order = 53)]
    public class ColorScheme : ScriptableObject
    {
        [field: SerializeField] public Color[] Colors { get; private set; }
    }
}