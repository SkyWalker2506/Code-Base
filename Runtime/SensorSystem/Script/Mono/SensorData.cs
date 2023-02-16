using System;

namespace CodeBase.SensorSystem
{
    [Serializable]
    public class SensorData
    {
        public SensorTargetType SensorTargetType;
        public int MaxSenseValue;
        public int SenseIncreaseValue;
        public int SenseDampingValue;
    }
}