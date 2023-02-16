using System;
using UnityEngine;

namespace CodeBase.SensorSystem
{
    public class SensorTarget : MonoBehaviour, ISensorTarget
    {
        public SensorTargetType SensorTargetType => _sensorTargetType;
        public Action OnSensed { get; }
        [SerializeField] SensorTargetType _sensorTargetType;
    }
}