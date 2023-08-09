using FiniteState;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public abstract class InteractableStateController : IStateController
    {
        public IInteractable Interactable { get; }
        public InteractableStateController(IInteractable interactable)
        {
            Interactable = interactable;
        }
        
        public IState CurrentState { get; private set; }
        public void SetCurrentState(IState state)
        {
            if (CurrentState != null)
            {
                CurrentState.OnStateExit();
            }

            CurrentState = state;
            CurrentState.OnStateEnter();
        }

        public void UpdateState()
        {
            if (CurrentState != null)
            {
                CurrentState.OnStateUpdate();
            }
        }
    }
}