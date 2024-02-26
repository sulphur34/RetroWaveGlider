using UnityEngine;

public class ScenarioData
{
    private CameraData _cameraData;



    public ScenarioData(CameraData cameraData, float gapLimit, float quadWidth, float maxYOffcet, float startPointY)
    {
        _cameraData = cameraData;
        GapLimit = gapLimit;
        QuadWidth = quadWidth;
        MaxYOffcet = maxYOffcet;
        StartPointY = startPointY;
    }

    public float GapLimit { get; private set; }
    public float QuadWidth { get; private set; }
    public float MaxYOffcet { get; private set; }
    public float RemoveBorder => _cameraData.LeftBorder;
    public float StartPointY { get; private set; }
}
