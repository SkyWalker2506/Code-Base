using UnityEngine;

namespace CodeBase.EventSystem.KeyEvent
{
    public class KeyUpEvent : KeyEvent
    {
        protected override void TryCallingEvent(KeyEventData data)
        {
            if (Input.GetKeyUp(data.Key))
                data.Event?.Invoke();
        }
    }
}