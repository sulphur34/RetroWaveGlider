namespace Assets.Scripts.TerrainSystem
{
    public class GapData
    {
        public GapData(float upperMinLimit, float upperMaxLimit, float lowerMinLimit, float lowerMaxLimit)
        {
            UpperMinLimit = upperMinLimit;
            UpperMaxLimit = upperMaxLimit;
            LowerMinLimit = lowerMinLimit;
            LowerMaxLimit = lowerMaxLimit;
        }

        public float UpperMinLimit { get; private set; }
        public float UpperMaxLimit { get; private set; }
        public float LowerMinLimit { get; private set; }
        public float LowerMaxLimit { get; private set; }
    }
}
