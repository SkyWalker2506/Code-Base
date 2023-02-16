using UnityEngine;

namespace CodeBase.SensorSystem
{
    public class AreaSensorLogic : SensorLogic
    {
        public AreaSensorLogic(AreaSensorData areaSensorData)
        {
            _areaSensorData = areaSensorData;
        }

        public override ISensorTarget IsSensing()
        {
            Collider[] hitColliders = Physics.OverlapSphere(_areaSensorData.Center.position,_areaSensorData.Area);
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent(out ISensorTarget target))
                {
                    if (target.SensorTargetType == _areaSensorData.SensorTargetType)
                    {
                        return target;
                    }
                }
            }
            return null;
        }
    }
}