using UnityEngine;

namespace Assets.Scripts.ObstaclesSystem
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Brick : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        public float Width { get; private set; }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            Width = _spriteRenderer.bounds.size.x;
        }
    }
}