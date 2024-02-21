using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Rigidbody2D _rigidbody;
    private Vector2 _zeroVerticalVelocity;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private Quaternion _zeroRotation;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _zeroVerticalVelocity = new Vector2(_speed, 0);
        _zeroRotation = Quaternion.Euler(0, 0, 0);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void AddVerticalVelocity()
    {
        _rigidbody.velocity = _zeroVerticalVelocity;
        transform.rotation = _maxRotation;
        _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
    }

    public void Reset()
    {
        _rigidbody.velocity = _zeroVerticalVelocity;
        transform.position = _startPosition;
        transform.rotation = _zeroRotation;
    }
}
