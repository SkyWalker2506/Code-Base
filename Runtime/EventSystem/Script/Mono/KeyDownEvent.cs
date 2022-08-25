using UnityEngine;

namespace EventSystem
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