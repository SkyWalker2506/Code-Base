using ConditionBaseStateSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "StateSystem/StateLogic/Random Walk", fileName = "Random Walk", order = 0)]
public class RandomWalkLogic : ScriptableStateLogic
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 startPos;
    [SerializeField] float maxX;
    [SerializeField] float maxZ;
    public override void Initialize(IState owner)
    {
        base.Initialize(owner);
        _navMeshAgent = owner.Owner.GetComponent<NavMeshAgent>();
        startPos = owner.Owner.transform.position;
    }

    public override void Act()
    {
        Vector3 randomPose = new Vector3(Random.Range(startPos.x - maxX, startPos.x + maxX), 0, Random.Range(startPos.z - maxZ, startPos.z + maxZ));
        _navMeshAgent.SetDestination(randomPose);
    }
}
