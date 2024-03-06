namespace TerrainSystem
{
    public abstract class Pattern
    {
        public abstract void GenerateTerrain(TerrainMesh terrainMesh, float lowerLimit, float upperLimit);
    }
}