namespace Assets.Scripts.ColorSystem.ColorTracker
{
    public class EnemyColorTrackerOne : ColorTrackerSprite
    {
        public override void Initialize()
        {
            ColorName = ColorNames.EnemyOne;
            base.Initialize();
            SetTracker();
        }
    }
}