using UnityEngine;
using UnityEngine.UI;

namespace ColorSystem.ColorTracker
{
    [RequireComponent(typeof(Image))]
    public class ColorTrackerUI : ColorTracker
    {
        private Image _image;

        protected override void SetTracker()
        {
            _image = GetComponent<Image>();
            ColorData.ColorChanged += (color) => _image.color = AdjustColor(color);
        }
    }
}