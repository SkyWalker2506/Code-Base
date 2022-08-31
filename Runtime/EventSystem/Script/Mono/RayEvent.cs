using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    public class RayEvent : MonoBehaviour
    {
        [SerializeField] RayEventData[] rayEventDatas;
        public void CallRayEvent(Vector3 startPos, Vector3 target)
        {
            RaycastHit hit;
            var direction = (target - startPos).normalized;
            foreach (var data in rayEventDatas)
            {
                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity, data.RayLayer))
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

