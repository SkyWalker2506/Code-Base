﻿using UnityEngine;

namespace CodeBase.EventSystem.MouseEvent
{
    public class MouseDownEvent :  MouseEvent
    {
        protected override bool EventCondition(MouseEventData data)
        {
            return Input.GetMouseButtonDown(data.MouseButton);
        }
    }
}