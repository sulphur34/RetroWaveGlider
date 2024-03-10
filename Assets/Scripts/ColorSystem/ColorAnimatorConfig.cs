using UnityEngine;

namespace ColorSystem
{
    [CreateAssetMenu(menuName = "Color Animator Config", fileName = "Color Animator Config", order = 57)]
    public class ColorAnimatorConfig : ScriptableObject
    {
        [field: SerializeField] public ColorScheme[] ColorSchemes { get; private set; }
        [field: SerializeField, Range(0.001f, 1f)] public float HueChangeStep { get; private set; } = 0.1f;
        [field: SerializeField, Range(0.001f, 1f)] public float HueChangeDelay { get; private set; } = 0.001f;
        [field: SerializeField, Range(0.001f, 1f)] public float ColorTransitStep { get; private set; } = 0.01f;
        [field: SerializeField, Range(0.001f, 1f)] public float ColorTransitDelay { get; private set; } = 0.1f;
    }
}