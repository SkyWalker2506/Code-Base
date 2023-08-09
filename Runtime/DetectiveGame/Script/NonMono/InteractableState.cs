using FiniteState;

namespace DetectiveGame.FiniteStateSystem
{
    public abstract class InteractableState : IState
    {
        protected InteractableStateController InteractableStateController { get; }
        protected InteractableState(InteractableStateController interactableStateController)
        {
            InteractableStateController = interactableStateController;
        }

        public virtual void OnStateEnter(){}

        public virtual void OnStateUpdate() {}

        public virtual void OnStateExit() {}
    }
}