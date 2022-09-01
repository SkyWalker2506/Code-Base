using EventSystem.RayEvent;
using UnityEngine;
using UnityEngine.Events;

namespace EventSystem
{
    public class ScriptableRaycastHitEventListener : ScriptableEventListener<RaycastHit>
    {
        [SerializeField] ScriptableRayEvent scriptableRay;

        protected override void SetEvent()
        {
            var datas = scriptableRay.Logic.RayEventDatas;
            foreach (var data in datas)
            {
                data.Event.AddListener(scriptableEvent.Invoke);
            }
        }

        protected override void UnsetEvent()
        {
            var datas = scriptableRay.Logic.RayEventDatas;
            foreach (var data in datas)
            {
                data.Event.RemoveListener(scriptableEvent.Invoke);
            }
        }
    }
}