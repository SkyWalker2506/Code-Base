using UnityEngine;

namespace MovementSystem
{
    public class PhysicalMove : IMove
    {
        public IMoveData MoveData { get; }
        private Rigidbody rigidbody { get; }

        public PhysicalMove(Rigidbody rigidbody, IMoveData moveData )
        {
            this.rigidbody = rigidbody;
            MoveData = moveData;
        }
        
        public void Move(Vector3 direction)
        {
            if (direction == Vector3.zero)
            {
                rigidbody.isKinematic = true;
            }
            else
            {
                rigidbody.isKinematic = false;
                rigidbody.velocity = direction * MoveData.MoveSpeed * Time.fixedDeltaTime;
            }
        }
    }
}