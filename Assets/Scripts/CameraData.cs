using UnityEngine;

public class CameraData : MonoBehaviour
{
    private Camera _camera;
    private Transform _transform;
    private Vector2 _startPosition;

    public float UpperBorder { get; private set; }
    public float LowerBorder { get; private set; }
    public float LeftBorder { get; private set; }
    public float RightBorder { get; private set; }
    public float Height { get; private set; }
    public float Width { get; private set; }
    public Vector2 CameraPosition => _transform.position;
    public float MoveDistance => Vector2.Distance(_startPosition, CameraPosition);

    private void Update()
    {
        SetBorders();
    }

    public void Initialize()
    {
        _transform = _camera.transform;
        _startPosition = _transform.position;
        _camera = Camera.main;
        SetBorders();
    }

    private void SetBorders()
    {
        Height = 2f * _camera.orthographicSize;
        Width = Height * _camera.aspect;

        Vector2 cameraPosition = CameraPosition;

        LeftBorder = cameraPosition.x - Width / 2f;
        RightBorder = cameraPosition.x + Width / 2f;
        UpperBorder = cameraPosition.y + Height / 2f;
        LowerBorder = cameraPosition.y - Height / 2f;
    }
}