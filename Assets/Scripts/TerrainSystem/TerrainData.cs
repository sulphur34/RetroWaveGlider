namespace Assets.Scripts.TerrainSystem
{
    public class TerrainData
    {
        public TerrainData(float xStart, float yStart, float xDelta, float yDelta, int xSize)
        {
            XStart = xStart;
            YStart = yStart;
            XDelta = xDelta;
            YDelta = yDelta;
            XSize = xSize;
        }

        public float XStart { get; private set; }
        public float YStart { get; private set; }
        public float XDelta { get; private set; }
        public float YDelta { get; private set; }
        public int XSize { get; private set; }
    }
}