using UnityEngine;

namespace InteractionSystem
{
    public interface IOpenableRotating : IOpenable
    {
        Vector3 OpenedRotation { get; }
        Vector3 ClosedRotation { get; }        
    }
}