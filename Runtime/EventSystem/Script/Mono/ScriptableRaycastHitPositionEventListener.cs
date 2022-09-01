using EventSystem.RayEvent;
using UnityEngine;

namespace EventSystem
{
    public class ScriptableRaycastHitPositionEventListener : ScriptableEventListener<Vector3>
    {
        [SerializeField] ScriptableRayEvent scriptableRay;

        protected override void SetEvent()
        {
            var datas = scriptableRay.Logic.RayEventDatas;
            foreach (var data in datas)
            {
                data.Event.AddListener(RaycastHitToPosCaller);
            }
        }

        protected override void UnsetEvent()
        {
            var datas = scriptableRay.Logic.RayEventDatas;
            foreach (var data in datas)
            {
                data.Event.RemoveListener(RaycastHitToPosCaller);
            }
        }

        void RaycastHitToPosCaller(RaycastHit raycastHit)
        {
            scriptableEvent.Invoke(raycastHit.point);
        }
    }
}