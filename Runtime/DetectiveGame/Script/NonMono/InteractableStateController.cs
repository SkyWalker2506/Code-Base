using FiniteState;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public abstract class InteractableStateController : IStateController
    {
        public IInteractable Interactable { get; }
        public IState CurrentState { get; private set; }

        protected InteractableStateController(IInteractable interactable)
        {
            Interactable = interactable;
        }
        
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