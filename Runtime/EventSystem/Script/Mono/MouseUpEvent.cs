using UnityEngine;


namespace EventSystem.MouseEvent
{
    public class MouseUpEvent : MouseEvent
    {
        protected override bool EventCondition(MouseEventData data)
        {
            return Input.GetMouseButtonUp(data.MouseButton);
        }
    }
}