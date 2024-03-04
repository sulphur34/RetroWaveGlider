namespace Assets.Scripts.ColorSystem.ColorTracker
{
    public class EnemyColorTrackerTwo : ColorTrackerSprite
    {
        public override void Initialize()
        {
            ColorName = ColorNames.EnemyTwo;
            base.Initialize();
            SetTracker();
        }
    }
}