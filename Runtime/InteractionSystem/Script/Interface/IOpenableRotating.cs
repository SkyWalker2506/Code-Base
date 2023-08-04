using UnityEngine;

namespace InteractionSystem
{
    public interface IOpenableRotating : IOpenable
    {
        Vector3 OpenRotation { get; }
        Vector3 CloseRotation { get; }        
    }
}