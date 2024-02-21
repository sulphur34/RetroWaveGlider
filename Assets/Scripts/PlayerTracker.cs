using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private float _offsetsX;

    private Glider _glider;
    
    private void Update()
    {
        transform.position = new Vector3(_glider.transform.position.x - _offsetsX, transform.position.y, transform.position.z);
    }

    public void Initialize(Glider glider)
    {
        _glider = glider;
    }

}
