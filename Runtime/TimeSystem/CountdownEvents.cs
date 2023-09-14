using System;

namespace TimeSystem
{
    public class CountdownEvents:ICountdownEvents
    {
        public Action OnCountdownStarted { get; }
        public Action<float> OnTicked { get; set; }
        public Action OnCountdownPaused { get; }
        public Action OnCountdownResumed { get; }
        public Action OnCountdownEnded { get; set; }
    }
}