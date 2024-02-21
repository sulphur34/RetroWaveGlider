using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorTrackerUI : MonoBehaviour, IColorable
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Initialize(IColorData colorData)
    {
        colorData.ColorChanged += (color) => _image.color = color;
    }
}
