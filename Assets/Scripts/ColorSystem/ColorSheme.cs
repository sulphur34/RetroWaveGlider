using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ColorSystem
{
    [CreateAssetMenu(menuName = "Color Scheme", fileName = "Color Scheme", order = 53)]
    public class ColorSheme : ScriptableObject
    {
        [SerializeField] private Color[] _colors;

        public Dictionary<string, Color> Colors { get; private set; }

        public void Initialize()
        {
            Colors = GetListedColors();
        }

        private Dictionary<string, Color> GetListedColors()
        {
            var colors = new Dictionary<string, Color>();

            for (int i = 0; i < _colors.Length; i++)
            {
                colors.Add(ColorNames.Names[i], _colors[i]);
            }

            return colors;
        }
    }
}