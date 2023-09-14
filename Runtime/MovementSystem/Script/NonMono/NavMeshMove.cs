using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace MovementSystem
{
    public class NavMeshMove : IMove
    {
        private INavmeshMovementData navmeshMovementData;
        public IMoveData MoveData => navmeshMovementData;
        private NavMeshAgent navMeshAgent;
        private float lastAvoidTime;
        public NavMeshMove(INavmeshMovementData navmeshMovementData, NavMeshAgent navMeshAgent)
        {
            this.navmeshMovementData = navmeshMovementData;
            this.navMeshAgent = navMeshAgent;
            navMeshAgent.speed = navmeshMovementData.MoveSpeed;
            navMeshAgent.angularSpeed = navmeshMovementData.RotateSpeed;
            navMeshAgent.acceleration = navmeshMovementData.Acceleration;
            navMeshAgent.radius = navmeshMovementData.ObstacleAvoidanceRadius;
        }

        public void Move(Vector3 targetPos)
        {
            navmeshMovementData.NavMeshAgent.SetDestination(targetPos);
        }

        public bool HasReachedTheDestination()
        {
            return navmeshMovementData.NavMeshAgent.remainingDistance < navmeshMovementData.MinRemainingDistance;
        }

        public void AvoidObstacle()
        {
            if (Time.realtimeSinceStartup - lastAvoidTime < 1)
            {
                return;
            }
            var position = navMeshAgent.transform.position;
            var currentColliders = Physics.OverlapSphere(position, navmeshMovementData.ObstacleAvoidanceRadius,navmeshMovementData.ObstacleLayer);
            if (currentColliders.Length > 0)
            {
                var direction =  currentColliders[0].transform.position-position;
                var target= position - 2 *direction;
                Move(target);
                lastAvoidTime = Time.realtimeSinceStartup;
                Debug.DrawLine(position, target, Color.magenta, .2f);
            }
        }
    }
}