using System;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.EventSystem.MouseEvent
{
    [Serializable]
    public struct MouseEventData
    {
        public int MouseButton;
        public UnityEvent<Vector2> Event;
    }
}

