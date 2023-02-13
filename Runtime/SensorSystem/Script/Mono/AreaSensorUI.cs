using UnityEngine;

namespace CodeBase.SensorSystem
{
    public class AreaSensorUI : SensorUI
    {
        [SerializeField] private AreaSensor _sensor;
        protected override ISensor Sensor => _sensor;
    }
}