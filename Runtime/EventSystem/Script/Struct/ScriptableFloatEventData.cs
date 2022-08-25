using System;
using UnityEngine.Events;

namespace EventSystem
{
    [Serializable]
        public struct ScriptableFloatEventData
        {
            public ScriptableFloat ScriptableFloat;
            public UnityEvent<float> Event;
        }

}

