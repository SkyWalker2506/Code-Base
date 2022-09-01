using System;
using UnityEngine;
using UnityEngine.Events;

namespace EventSystem.MouseEvent
{
    [Serializable]
    public struct MouseEventData
    {
        public int MouseButton;
        public UnityEvent<Vector2> Event;
    }
}

