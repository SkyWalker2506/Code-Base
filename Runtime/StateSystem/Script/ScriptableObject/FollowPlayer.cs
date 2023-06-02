using UnityEngine;
using UnityEngine.AI;

namespace StateSystem
{
    [CreateAssetMenu(menuName = "StateSystem/StateLogic/Create FollowPlayer", fileName = "FollowPlayer", order = 0)]
    public class FollowPlayer : ScriptableStateLogic
    {
        private NavMeshAgent _navMeshAgent;
        public override void Initialize(IState owner)
        {
            base.Initialize(owner);
            _navMeshAgent = owner.Owner.GetComponent<NavMeshAgent>();
        }

        public override void Act()
        {
        }
    }
}