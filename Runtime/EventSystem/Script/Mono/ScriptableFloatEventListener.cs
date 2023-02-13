using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.EventSystem
{
    public class ScriptableFloatEventListener : ScriptableEventListener<float>
    {
        [SerializeField] ScriptableFloat scriptableFloat;

        protected override void SetEvent()
        {
            scriptableFloat.OnValueChanged.AddListener(scriptableEvent.Invoke);
        }

        protected override void UnsetEvent()
        {
            scriptableFloat.OnValueChanged.RemoveListener(scriptableEvent.Invoke);
        }
    }
}