using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private float _offsetsX;
    [SerializeField] private Glider.Glider _glider;

    private void Update()
    {
        Vector3 position = transform.position;
        transform.Translate(new Vector3(_glider.transform.position.x - _offsetsX, position.y, position.z));
    }
}