using UnityEngine;
using UnityEngine.AI;

namespace MovementSystem
{
    public interface INavmeshMovementData : IMoveData, IRotateData
    {
        NavMeshAgent NavMeshAgent{ get; }
        float Acceleration { get; }
        float ObstacleAvoidanceRadius { get;  }
        LayerMask ObstacleLayer{ get;  }
        float MinRemainingDistance { get;  }

    }
}