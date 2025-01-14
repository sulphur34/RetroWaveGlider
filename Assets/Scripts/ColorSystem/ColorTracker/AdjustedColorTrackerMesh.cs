using UnityEngine;

namespace ColorSystem.ColorTracker
{
    public class AdjustedColorTrackerMesh : ColorTrackerMesh
    {
        [SerializeField] private float _britnessValue = 0.6f;

        protected override Color AdjustColor(Color color)
        {
            Color.RGBToHSV(color, out float hue, out float saturation, out _);
            return Color.HSVToRGB(hue, saturation, _britnessValue);
        }
    }
}