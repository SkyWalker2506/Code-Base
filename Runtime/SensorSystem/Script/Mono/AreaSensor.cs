using UnityEngine;

namespace CodeBase.SensorSystem
{
    public class AreaSensor : Sensor
    {
        [SerializeField] private AreaSensorData _areaSensorData;

        private void Awake()
        {
            SensorLogic = new AreaSensorLogic(_areaSensorData);
        }

    }
}