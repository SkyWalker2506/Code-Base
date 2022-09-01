using UnityEngine;

namespace EventSystem.RayEvent
{
    [CreateAssetMenu(menuName = "ScriptableRayEvent")]
    public class ScriptableRayEvent : ScriptableObject,IRayEvent
    {
        [SerializeField] RayEventLogic logic = new RayEventLogic();

        public void CallRayEvent(Vector3 target)
        {
            logic.CallRayEvent(target);
        }
        
        public void CallRayEvent(Vector3 startPos, Vector3 target)
        {
            logic.CallRayEvent(startPos, target);
        }

        
    }
}

