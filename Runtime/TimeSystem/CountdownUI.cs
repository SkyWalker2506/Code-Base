using System;
using UnityEngine;
using UnityEngine.UI;

namespace TimeSystem
{
    public class CountdownUI : MonoBehaviour
    {
        [SerializeField] private Text countdownText;
        private String leftTime;
        private CountdownManager countdownManager;
        private void Awake()
        {
            countdownManager = FindObjectOfType<CountdownManager>();
            countdownText.text="time.ToString()";
        }

        //UpdateTime da text i yeniliyince anlamadığım bir sebepten ötürü text inspectorde değişse bile UI da değişmiyor.
        //Bu sebeple update de tekrar set etmeyi denedim. Benzer olay UIManager da da yaşandı. Bunu çözmeye çok zaman
        //harcadığım için şimdilik bu şekilde brakıp, diğer istenilen şeylere devam ediyorum.
        private void Update()
        {
            countdownText.text = leftTime;
        }

        private void OnEnable()
        {
            if (countdownManager)
            {
                countdownManager.OnTicked+=UpdateTime;
            }
        }

        private void OnDisable()
        {
            if (countdownManager)
            {
                countdownManager.OnTicked-=UpdateTime;
            }
        }
        void UpdateTime(float time)
        {
            TimeSpan ts = TimeSpan.FromSeconds(time);
            leftTime = $"{ts.Minutes}:{ts.Seconds}";
            if (ts.Minutes < 10)
            {
                leftTime= leftTime.Insert(0, "0");
            }
            if (ts.Seconds < 10)
            {
                leftTime= leftTime.Insert(3, "0");
            }
        }

    }

}