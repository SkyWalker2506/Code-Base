using System;
using UnityEngine;

namespace CodeBase.SensorSystem
{
    public abstract class Sensor : MonoBehaviour, ISensor
    {
        public ISensorLogic SensorLogic { get; protected set; }
        public Action OnSenseFilled { get; set; }

        private void Update()
        {
            SensorLogic.Update();
            if (SensorLogic.SensorPercentage >= 1)
            {
                OnSenseFilled?.Invoke();
            }
        }
    }
}