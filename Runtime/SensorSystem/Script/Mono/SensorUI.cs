using UnityEngine;

namespace CodeBase.SensorSystem
{
    public abstract class SensorUI : MonoBehaviour
    {
        protected abstract ISensor Sensor { get; }

        private void OnEnable()
        {
            Sensor.OnSense += OnSense;
        }

        private void OnDisable()
        {
            Sensor.OnSense -= OnSense;
        }

        private void OnSense()
        {
            Debug.Log("Sensed UI");
        }
    }
}