using UnityEngine;

namespace Glider
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class GliderMover : MonoBehaviour
    {
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private float _speed;
        [SerializeField] private float _accelerationSpeed;
        [SerializeField] private float _tapForce;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _minRotationZ;
        [SerializeField] private float _maxRotationZ;

        private Rigidbody2D _rigidbody;
        private Quaternion _minRotation;
        private Quaternion _maxRotation;
        private Quaternion _zeroRotation;
        private float _currentSpeed;

        private void Start()
        {
            _currentSpeed = _speed;
            _rigidbody = GetComponent<Rigidbody2D>();
            _zeroRotation = Quaternion.Euler(0, 0, 0);
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
            AddVerticalVelocity();
        }

        private Vector2 _zeroVerticalVelocity => new Vector2(_currentSpeed, 0);

        private void FixedUpdate()
        {
            _rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime));
        }

        public void AddVerticalVelocity()
        {
            _rigidbody.velocity = _zeroVerticalVelocity;
            _rigidbody.AddTorque(40f);
            _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        }

        public void AddHorizontalVelocity()
        {
            _currentSpeed = Mathf.Lerp(_currentSpeed, _accelerationSpeed, Time.deltaTime);
            _rigidbody.velocity = new Vector2(_currentSpeed, _rigidbody.velocity.y);
        }

        public void Reset()
        {
            _rigidbody.velocity = _zeroVerticalVelocity;
            transform.position = _startPosition;
            transform.rotation = _zeroRotation;
        }
    }
}