using System;
using UnityEngine;

namespace EventSystem
{
    [Serializable]
    public class RayEventLogic 
    {

        [SerializeField] RayEventData[] rayEventDatas;
        public void CallRayEvent(Vector3 startPos, Vector3 target)
        {
            RaycastHit hit;
            var direction = (target - startPos).normalized;
            foreach (var data in rayEventDatas)
            {
                if (Physics.Raycast(startPos, direction, out hit, Mathf.Infinity, data.RayLayer))
                {
                    data.Event?.Invoke(hit);
                }
            }
        }

        public void CallRayEvent(Vector3 target)
        {
            CallRayEvent(Camera.main.transform.position, target);
        }

    }
}

