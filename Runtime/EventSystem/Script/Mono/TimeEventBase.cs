using System;
using EventSystem;
using UnityEngine;

namespace CodeBase.EventSystem
{
    [Serializable]
    public class TimeEventBase : ITimeEvent
    {
        [SerializeField] TimeEventData timeEventData;

        public TimeEventData Data => timeEventData;
        float currentTime;
    
        public void Initialize()
        {
            SetCurrentTime(Data.InitialTime);
            Data.OnInitialize?.Invoke(currentTime);
        }

        public void EachTick()
        {
            SetCurrentTime(currentTime - Data.TickInterval);
            currentTime -= Data.TickInterval;
            Data.OnEveryTick?.Invoke(currentTime);
        }

        public void TimeEnded()
        {
            SetCurrentTime(0);
            Data.OnInitialize?.Invoke(currentTime);
        }

        public void SetCurrentTime(float time)
        {
            currentTime = time < 0 ?  0 : time;
        }
    }
}
