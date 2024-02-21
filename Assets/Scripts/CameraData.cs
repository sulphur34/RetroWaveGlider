using UnityEngine;

public class CameraData : MonoBehaviour
{
    private Camera _camera;

    public float UpperBorder { get; private set; }
    public float LowerBorder { get; private set; }
    public float LeftBorder { get; private set; }
    public float RightBorder { get; private set; }
    public float Height { get; private set; }
    public float Width { get; private set; }
    public Vector2 CameraPosition { get; private set; }

    private void Update()
    {
        SetBorders();
    }

    public void Initialize()
    {
        _camera = Camera.main;
        SetBorders();        
    }

    private void SetBorders()
    {
        Height = 2f * _camera.orthographicSize;
        Width = Height * _camera.aspect;

        CameraPosition = _camera.transform.position;

        LeftBorder = CameraPosition.x - Width / 2f;
        RightBorder = CameraPosition.x + Width / 2f;
        UpperBorder = CameraPosition.y + Height / 2f;
        LowerBorder = CameraPosition.y - Height / 2f;
    }
}
