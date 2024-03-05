using System;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private float _offsetX;
    [SerializeField] private Glider.Glider _glider;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        Vector3 position = transform.position;
        _transform.position = new Vector3(_glider.transform.position.x - _offsetX, position.y, position.z);
    }
}