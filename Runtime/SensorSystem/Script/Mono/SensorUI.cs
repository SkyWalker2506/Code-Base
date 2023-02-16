using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.SensorSystem
{
    public abstract class SensorUI : MonoBehaviour
    {
        [SerializeField] private Slider _sensorSlider;
        protected abstract ISensorLogic SensorLogic { get; }

        private void Start()
        {
            OnSense();
        }

        private void OnEnable()
        {
            SensorLogic.OnSense += OnSense;
        }

        private void OnDisable()
        {
            SensorLogic.OnSense -= OnSense;
        }

        private void OnSense()
        {
            _sensorSlider.value = SensorLogic.SensorPercentage;
        }
    }
}