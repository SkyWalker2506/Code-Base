using UnityEngine;


namespace CodeBase.EventSystem.MouseEvent
{
    public class MouseHoldEvent : MouseEvent
    {
        protected override bool EventCondition(MouseEventData data)
        {
            return Input.GetMouseButton(data.MouseButton);
        }
    }
}