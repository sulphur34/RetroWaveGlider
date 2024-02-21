using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class ColorTracker : MonoBehaviour, IColorable
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(IColorData colorData)
    {
        colorData.ColorChanged += (color) => _spriteRenderer.color = color;
    }
}
