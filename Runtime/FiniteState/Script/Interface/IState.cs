using UnityEngine;

namespace FiniteState
{
    public interface IState 
    {
        IStateController StateController { get; }
        void OnStateEnter();
        void OnStateUpdate();
        void OnStateExit();
    }
}
