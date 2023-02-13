using System;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.EventSystem.RayEvent
{
    [Serializable]
    public struct RayEventData
    {
        public LayerMask RayLayer;
        public UnityEvent<RaycastHit> Event;
    }
}

