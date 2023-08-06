using CodeBase.Core;
using FiniteState;

namespace InteractionSystem
{
    public interface IInteractable : IHaveTransform
    {
        bool IsInteractable{ get; }
        IInteraction[] Interactions{ get; }
        void Interact(int index);
    }

    public class DoorStateController : IStateController
    {
        public IState CurrentState { get; }
        public void SetCurrentState(IState state)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateState()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class DoorOpenedState : IState
    {
        public IStateController StateController { get; }
        public void OnStateEnter()
        {
            throw new System.NotImplementedException();
        }

        public void OnStateUpdate()
        {
            throw new System.NotImplementedException();
        }

        public void OnStateExit()
        {
            throw new System.NotImplementedException();
        }
    }
}