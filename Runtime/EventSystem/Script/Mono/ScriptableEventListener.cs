using UnityEngine;
using UnityEngine.Events;

namespace EventSystem
{
    public abstract class ScriptableEventListener<T> : MonoBehaviour
    {
        [SerializeField] UnityEvent<T> onChanged;
        protected UnityEvent<T> scriptableEvent=new UnityEvent<T>();
        void OnEnable()
        {
            SetEvent();
            scriptableEvent.AddListener(OnValueChanged);
        }

        void OnDisable()
        {
            UnsetEvent();
            scriptableEvent.RemoveListener(OnValueChanged);
        }

        void OnValueChanged(T value)
        {
            onChanged?.Invoke(value);
        }

        protected abstract void SetEvent();
        protected abstract void UnsetEvent();



    }
}