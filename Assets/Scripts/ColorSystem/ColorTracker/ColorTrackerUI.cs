using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorTrackerUI : ColorTracker
{
    private Image _image;

    public override void Initialize()
    {
        base.Initialize();
    }

    protected override void SetTracker()
    {
        _image = GetComponent<Image>();
        ColorData.ColorChanged += (color) => _image.color = color;
    }
}
