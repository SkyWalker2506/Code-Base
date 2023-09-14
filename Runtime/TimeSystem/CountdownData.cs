using System;
using UnityEngine;
using UnityEngine.Events;

namespace TimeSystem
{
    [CreateAssetMenu(menuName = "TimeSystem/Create Countdown Data", fileName = "Countdown Data")]
    public class CountdownData : ScriptableObject, ICountdownData
    {
        [field:SerializeField] public bool StartCountdownOnAwake{ get; private set; }      
        [field:SerializeField] public float CountdownTime{ get; private set; }
        [field:Tooltip("Milliseconds")][field:SerializeField] public float TickInterval { get; private set; }
    }
}