using UnityEngine;

namespace MovementSystem
{
    public interface IMove
    {
        IMoveData MoveData { get; }
        void Move(Vector3 direction);
    }
}
