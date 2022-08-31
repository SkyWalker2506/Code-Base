using UnityEngine;
using UnityEngine.Events;

namespace EventSystem
{
    public class ScriptableFloatEventListener : MonoBehaviour
    {
        [SerializeField] ScriptableFloat scriptableFloat;
        [SerializeField] UnityEvent<float> OnChanged;
        
        void OnEnable()
        {
            scriptableFloat.OnValueChanged.AddListener(OnValueChanged);
        }

        void OnDisable()
        {
            scriptableFloat.OnValueChanged.RemoveListener(OnValueChanged);
        }

        void OnValueChanged(float value)
        {
            OnChanged?.Invoke(value);
        }
    }
}