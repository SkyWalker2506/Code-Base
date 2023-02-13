using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.EventSystem.RayEvent
{

    public class RayEvent : MonoBehaviour
    {
        [SerializeField] RayEventLogic logic = new RayEventLogic();

        public void CallRayEvent(Vector3 startPos, Vector3 target)
        {
            logic.CallRayEvent(startPos,target);
        }

        public void CallRayEvent(Vector3 target)
        {
            logic.CallRayEvent(target);
        }
    }
}

