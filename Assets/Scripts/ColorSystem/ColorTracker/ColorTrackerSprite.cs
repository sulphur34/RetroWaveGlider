using UnityEngine;

namespace Assets.Scripts.ColorSystem.ColorTracker
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ColorTrackerSprite : ColorTracker
    {
        private SpriteRenderer _spriteRenderer;

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void SetTracker()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            ColorData.ColorChanged += (color) => _spriteRenderer.color = color;
        }
    }
}