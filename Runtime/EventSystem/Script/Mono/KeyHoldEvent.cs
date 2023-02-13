using UnityEngine;

namespace CodeBase.EventSystem.KeyEvent
{
    public class KeyHoldEvent : KeyEvent
    {
        protected override void TryCallingEvent(KeyEventData data)
        {
            if (Input.GetKey(data.Key))
                data.Event?.Invoke();
        }
    }
}