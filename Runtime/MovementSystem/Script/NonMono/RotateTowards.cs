using UnityEngine;

namespace MovementSystem
{
    public class RotateTowards : IRotate
    {
        public IRotateData RotateData { get; }
        private Transform transform;
        private Vector3 direction;
        
        public RotateTowards(Transform transform, IRotateData rotateData)
        {
            this.transform = transform;
            RotateData = rotateData;
            direction = transform.forward;
        }
        
        public void SetTarget(Vector3 targetDirection)
        {
            direction = targetDirection;
        }
        
        public void Rotate()
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation,
                RotateData.RotateSpeed * Time.deltaTime);
        }
    }
}