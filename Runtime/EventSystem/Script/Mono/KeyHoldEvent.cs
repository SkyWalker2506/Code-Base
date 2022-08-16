using UnityEngine;

namespace EventSystem
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