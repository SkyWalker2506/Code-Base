using System;
using UnityEngine;

namespace CodeBase.SensorSystem
{
    [Serializable]
    public class AreaSensorData : SensorData
    {
        public Transform Center;
        public float Area;
    }
}