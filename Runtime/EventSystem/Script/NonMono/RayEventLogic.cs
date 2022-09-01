using System;
using UnityEngine;

namespace EventSystem.RayEvent
{
    [Serializable]
    public class RayEventLogic : IRayEvent 
    {

        public RayEventData[] RayEventDatas;
        
        public void CallRayEvent(Vector3 target)
        {
            CallRayEvent(Camera.main.transform.position, target);
        }
        public void CallRayEvent(Vector3 startPos, Vector3 target)
        {
            RaycastHit hit;
            var direction = (target - startPos).normalized;
            foreach (var data in RayEventDatas)
            {
                if (Physics.Raycast(startPos, direction, out hit, Mathf.Infinity, data.RayLayer))
                {
                    data.Event?.Invoke(hit);
                }
            }
        }

    }
}

