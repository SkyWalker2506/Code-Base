using UnityEngine;

namespace MovementSystem
{
    public interface IRotate
    {
        IRotateData RotateData { get; }
        void SetTarget(Vector3 direction);
        void Rotate();
    }
}
