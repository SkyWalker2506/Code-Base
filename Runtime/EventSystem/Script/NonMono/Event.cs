using UnityEngine.Events;

namespace CodeBase.EventSystem
{
    public class Event : IEvent
    {
        public UnityEvent Action { get; set; } = new UnityEvent();
    }

}
