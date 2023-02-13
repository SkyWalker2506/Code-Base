using UnityEngine.Events;

namespace CodeBase.EventSystem
{
    public interface IEvent
    {
        UnityEvent Action { get; set; }
    }
}
