using UnityEngine;

namespace EventSystem
{
    [CreateAssetMenu(menuName = "ScriptableRayEvent")]
    public class ScriptableRayEvent : ScriptableObject
    {
        [SerializeField] RayEventLogic logic = new RayEventLogic();

        public void CallRayEvent(Vector3 startPos, Vector3 target)
        {
            logic.CallRayEvent(startPos, target);
        }

        public void CallRayEvent(Vector3 target)
        {
            logic.CallRayEvent(target);
        }
    }
}

