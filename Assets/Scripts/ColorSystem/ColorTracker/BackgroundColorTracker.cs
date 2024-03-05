namespace ColorSystem.ColorTracker
{
    public class BackgroundColorTracker : ColorTrackerUI
    {
        public override void Initialize()
        {
            ColorName = ColorNames.Background;
            base.Initialize();
            SetTracker();
        }
    }
}