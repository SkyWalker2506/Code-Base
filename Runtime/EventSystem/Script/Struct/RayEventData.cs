﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace EventSystem
{
    [Serializable]
    public struct RayEventData
    {
        public LayerMask RayLayer;
        public UnityEvent<RaycastHit> Event;
    }
}

