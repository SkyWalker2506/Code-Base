using System;
using UnityEngine;

namespace TimeSystem
{
    public class CountdownManager : MonoBehaviour
    {
        [SerializeField] private CountdownData countdownData;
        ICountdown countdown { get; set; }

        public Action<float> OnTicked;
        public Action OnCountdownEnded;
        private void Awake()
        {

            if (countdownData.StartCountdownOnAwake)
            {
                StartCountdown();
            }
        }

        private void StartCountdown()
        {
            countdown = new Countdown(countdownData);
            countdown.StartCountdown();
        }

        private void OnEnable()
        {
            countdown.CountdownEvents.OnTicked += Ticked;
            countdown.CountdownEvents.OnCountdownEnded += CountdownEnded;
        }
        
        private void OnDisable()
        {
            countdown.CountdownEvents.OnTicked -= Ticked;
            countdown.CountdownEvents.OnCountdownEnded -= CountdownEnded;
            if (countdown != null)
            {
                countdown.CancelCountdown();
            }
        }
        
        void Ticked(float x) => OnTicked?.Invoke(x);
        void CountdownEnded() => OnCountdownEnded?.Invoke();


    }
}