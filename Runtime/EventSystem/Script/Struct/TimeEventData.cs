using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace EventSystem
{
    public struct TimeEventData
    {
        public bool InitializeOnStart;
        public float InitialTime;
        public float TickInterval;
        public UnityEvent<float> OnInitialize;
        public UnityEvent<float> OnEveryTick;
        public UnityEvent<float> OnTimeEnded;
    }
}
