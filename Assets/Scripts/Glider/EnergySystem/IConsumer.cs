namespace Glider.EnergySystem
{
    public interface IConsumer
    {
        public float ConcumeValue { get; }

        public void Activate();
    }
}