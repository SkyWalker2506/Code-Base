using System;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.EventSystem.KeyEvent
{
    [Serializable]
    public struct KeyEventData
    {
        public KeyCode Key;
        public UnityEvent Event;
    }
}

namespace EventSystem.MouseEvent
{
}

