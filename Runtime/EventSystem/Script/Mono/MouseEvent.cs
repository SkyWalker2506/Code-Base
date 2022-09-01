using UnityEngine;


namespace EventSystem.MouseEvent
{
    public abstract class MouseEvent : MonoBehaviour
    {
        [SerializeField] protected MouseEventData[] mouseEventData;
        private void Update()
        {
            foreach (var data in mouseEventData)
            {
                if (EventCondition(data))
                    CallEvent(data);
            }
        }
        protected abstract bool EventCondition(MouseEventData data);

        protected virtual void CallEvent(MouseEventData data)
        {
            data.Event?.Invoke(Input.mousePosition);
        }
    }
}