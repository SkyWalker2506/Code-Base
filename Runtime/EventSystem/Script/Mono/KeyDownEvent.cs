using UnityEngine;

namespace CodeBase.EventSystem.KeyEvent
{
        public class KeyDownEvent : KeyEvent
        {
            protected override void TryCallingEvent(KeyEventData data)
            {
                if (Input.GetKeyDown(data.Key))
                    data.Event?.Invoke();
            }
        }
 

}