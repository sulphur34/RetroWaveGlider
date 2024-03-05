namespace ColorSystem.ColorTracker
{
    public class ObstacleColorTracker : ColorTrackerMesh
    {
        public override void Initialize()
        {
            ColorName = ColorNames.Obstacle;
            base.Initialize();
            SetTracker();
        }
    }
}