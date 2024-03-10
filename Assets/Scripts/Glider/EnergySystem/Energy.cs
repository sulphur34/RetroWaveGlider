using UnityEngine;

namespace Glider.EnergySystem
{
    public class Energy : IConsumable
    {
        private readonly float _minCapacity = 0f;
        private readonly float _restoreStep;
        private readonly float _maxCapacity;

        private float _currentValue;

        public Energy(float maxCapacity, float restoreStep)
        {
            _maxCapacity = maxCapacity;
            _restoreStep = restoreStep;
            _currentValue = _maxCapacity;
        }

        public void Consume(IConsumer consumer)
        {
            if (_currentValue >= consumer.ConcumeValue)
            {
                _currentValue -= consumer.ConcumeValue;
                consumer.Activate();
            }
        }

        public void Restore()
        {
            Set(_currentValue + _restoreStep);
        }

        private void Set(float energyValue)
        {
            _currentValue = Mathf.Clamp(energyValue, _minCapacity, _maxCapacity);
        }
    }
}