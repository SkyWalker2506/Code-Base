using System;
using UnityEngine;
using UnityEngine.Events;

namespace EventSystem
{
    [Serializable]
    public struct KeyEventData
    {
        public KeyCode Key;
        public UnityEvent Event;
    }
}