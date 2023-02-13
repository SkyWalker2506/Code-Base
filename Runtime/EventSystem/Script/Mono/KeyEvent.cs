using UnityEngine;

namespace CodeBase.EventSystem.KeyEvent
{
    public abstract class KeyEvent : MonoBehaviour
    {
        [SerializeField] protected KeyEventData[] keyEventDatas;
        private void Update()
        {
            foreach (var data in keyEventDatas)
            {
                TryCallingEvent(data);
            }
        }
        protected abstract void TryCallingEvent(KeyEventData data);

    }

}