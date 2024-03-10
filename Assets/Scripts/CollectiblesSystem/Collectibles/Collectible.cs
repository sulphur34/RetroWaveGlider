using UnityEngine;

namespace CollectiblesSystem.Collectibles
{
    public abstract class Collectible : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Glider.Glider glider))
            {
                OnCollision(glider);
            }
        }

        protected abstract void OnCollision(Glider.Glider glider);
    }
}
