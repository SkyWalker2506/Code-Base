using UnityEngine;

namespace CodeBase.SensorSystem
{
    public class AreaSensorUI : SensorUI
    {
        [SerializeField] private AreaSensor _areaSensor;
        protected override ISensorLogic SensorLogic => _areaSensor.SensorLogic;
    }
}