using System;
using UnityEngine;

namespace CodeBase.SensorSystem
{
    public class AreaSensor : MonoBehaviour, ISensor
    {
        public SensorTargetType SensorTargetType => _sensorTargetType;
        public Action OnSense { get; set; }
        [SerializeField] SensorTargetType _sensorTargetType;
        [SerializeField] private float _area;

        private void Update()
        {
            CheckTarget();
        }

        public void CheckTarget()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _area);
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent(out ISensorTarget target))
                {
                    if (target.SensorTargetType == SensorTargetType)
                    {
                        OnSense?.Invoke();
                        target.OnSensed?.Invoke(); 
                        return;
                    }
                }
            }
        }
    }
}