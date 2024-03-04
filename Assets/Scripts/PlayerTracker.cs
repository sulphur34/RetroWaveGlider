using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerTracker : MonoBehaviour
    {
        [SerializeField] private float _offsetsX;
        [SerializeField] private Glider.Glider _glider;

        private void Update()
        {
            transform.position = new Vector3(_glider.transform.position.x - _offsetsX, transform.position.y, transform.position.z);
        }
    }
}