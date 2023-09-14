using System;
using UnityEngine;
using UnityEngine.Events;

namespace TimeSystem
{
    public interface ICountdownEvents
    {
        public  Action OnCountdownStarted { get;  }
        public  Action<float> OnTicked { get; set; }
        public  Action OnCountdownPaused { get; }
        public  Action OnCountdownResumed { get;  }
        public  Action OnCountdownEnded { get; set; }
    }
}