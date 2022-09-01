using UnityEngine;

namespace EventSystem.RayEvent
{
    [CreateAssetMenu(menuName = "ScriptableRayEvent")]
    public class ScriptableRayEvent : ScriptableObject,IRayEvent
    {
        public RayEventLogic Logic = new RayEventLogic();

        public void CallRayEvent(Vector3 target)
        {
            Logic.CallRayEvent(target);
        }
        
        public void CallRayEvent(Vector3 startPos, Vector3 target)
        {
            Logic.CallRayEvent(startPos, target);
        }

        
    }
}

