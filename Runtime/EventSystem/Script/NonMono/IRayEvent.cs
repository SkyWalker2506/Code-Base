using UnityEngine;

namespace CodeBase.EventSystem.RayEvent
{
    public interface IRayEvent
    {
        public void CallRayEvent(Vector3 target);
        public void CallRayEvent(Vector3 startPos, Vector3 target);

    }
}

