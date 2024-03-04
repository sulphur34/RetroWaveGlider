namespace Assets.Scripts.ColorSystem.ColorTracker
{
    public class GliderColorTracker : ColorTrackerSprite
    {
        public override void Initialize()
        {
            ColorName = ColorNames.Glider;
            base.Initialize();
            SetTracker();
        }
    }
}