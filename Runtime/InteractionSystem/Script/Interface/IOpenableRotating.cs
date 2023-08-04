using UnityEngine;

namespace InteractionSystem
{
    public interface IOpenableRotating : IOpenable
    {
        Quaternion OpenedRotation { get; }
        Quaternion ClosedRotation { get; }        
    }
}