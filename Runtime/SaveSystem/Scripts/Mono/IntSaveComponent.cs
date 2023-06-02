using System;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Events;

namespace SaveSystem
{
    public class IntSaveComponent : SaveComponentBase
    {
        public UnityEvent<int> SetInt;

        [SerializeField] private int _value;


        public void SetValue(int value)
        {
            _value = value;
        }
        
        public override string GetSerializedValue()
        {
            return _value.ToString();
        }

        public override void LoadData(string value)
        {
            _value = JsonConvert.DeserializeObject<int>(value);
            SetInt?.Invoke(_value);
        }
    }
}