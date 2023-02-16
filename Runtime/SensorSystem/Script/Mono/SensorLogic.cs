using System;

namespace CodeBase.SensorSystem
{
    public abstract class SensorLogic : ISensorLogic
    {
        public float SensorPercentage => 1f * _currentSenseValue / _areaSensorData.MaxSenseValue;
        public Action OnSense { get; set; }

        protected AreaSensorData _areaSensorData;
        private int _currentSenseValue=0;
        
        public void Update()
        {
            ISensorTarget target = IsSensing();
            if (target != null)
            {
                UpdateCurrentSenseValue(_currentSenseValue + _areaSensorData.SenseIncreaseValue);
                target.OnSensed?.Invoke(); 
            }
            else
            {
                UpdateCurrentSenseValue(_currentSenseValue - _areaSensorData.SenseDampingValue);
            }

        }

        public abstract ISensorTarget IsSensing();

        private void UpdateCurrentSenseValue(int senseValue)
        {
            _currentSenseValue = Math.Clamp(senseValue, 0, _areaSensorData.MaxSenseValue);
            OnSense?.Invoke();
        }
    }
}