using System.Timers;

namespace TimeSystem
{
    public class Countdown : ICountdown
    {
        public float CountdownTime { get; }
        public float LeftTime { get; private set; }
        public float TickInterval { get; }
        public CountdownEvents CountdownEvents { get; } = new CountdownEvents();
        private Timer timer;
        
        public Countdown(ICountdownData countdownData)
        {
            CountdownTime = countdownData.CountdownTime;
            TickInterval = countdownData.TickInterval;
        }
        
        public void StartCountdown()
        {
            LeftTime = CountdownTime;
            timer = new Timer(TickInterval);
            timer.Elapsed += OnTimerElapsed;
            timer.Enabled = true;
            timer.Start();
            CountdownEvents.OnCountdownStarted?.Invoke();
            CountdownEvents.OnTicked?.Invoke(LeftTime);
        }

        public void CancelCountdown()
        {
            timer.Elapsed -= OnTimerElapsed;
            timer.Enabled = false;
            timer.Stop();
            timer.Dispose();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Tick();
        }

        public void Tick()
        {
            if(!timer.Enabled)
                return;
            LeftTime -= TickInterval*.001f;
            CountdownEvents.OnTicked?.Invoke(LeftTime);
            if (LeftTime <= 0)
            {
                LeftTime = 0;
                timer.AutoReset = false;
                CountdownEvents.OnTicked?.Invoke(LeftTime);
                CountdownEvents.OnCountdownEnded?.Invoke();
                CancelCountdown();
            }
        }

        public void PauseCountdown()
        {
            timer.Stop();
            CountdownEvents.OnCountdownPaused?.Invoke();
        }

        public void ResumeCountdown()
        {
            timer.Start();
            CountdownEvents.OnCountdownResumed?.Invoke();
        }
    }
}