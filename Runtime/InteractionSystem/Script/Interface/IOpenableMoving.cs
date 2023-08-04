using UnityEngine;

namespace InteractionSystem
{
    public interface IOpenableMoving : IOpenable
    {
        Vector3 OpenedPosition { get; }
        Vector3 ClosedPosition { get; }
    }
}