namespace TerrainSystem
{
    public abstract class Scenario
    {
        public abstract void GenerateTerrain(TerrainMesh terrainMesh, float lowerLimit, float upperLimit);
    }
}