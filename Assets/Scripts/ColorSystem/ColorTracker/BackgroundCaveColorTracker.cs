using Assets.Scripts.ColorSystem;
using Assets.Scripts.ColorSystem.ColorTracker;

public class BackgroundCaveColorTracker : ColorTrackerMesh
{
    public override void Initialize()
    {
        ColorName = ColorNames.MovableBackground;
        base.Initialize();
        SetTracker();
    }
}