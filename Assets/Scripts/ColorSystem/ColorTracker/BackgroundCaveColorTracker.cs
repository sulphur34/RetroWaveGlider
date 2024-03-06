using UnityEngine;

namespace ColorSystem.ColorTracker
{
    public class BackgroundCaveColorTracker : ColorTrackerMesh
    {
        [SerializeField] private float _britnessValue = 0.6f;
        public override void Initialize()
        {
            ColorName = ColorNames.Background;
            base.Initialize();
            SetTracker();
        }

        protected override Color AdjustColor(Color color)
        {
            Color.RGBToHSV(color, out float hue, out float saturation, out _);
            return Color.HSVToRGB(hue, saturation, _britnessValue);
        }
    }
}
