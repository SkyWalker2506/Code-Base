using System;
using FiniteState;

namespace DetectiveGame.FiniteStateSystem
{
    public abstract class InteractableState : IState
    {
        protected InteractableStateController ISC { get; }
        public Action OnInteractionEnded{ get; set; }
        protected InteractableState(InteractableStateController interactableStateController)
        {
            ISC = interactableStateController;
        }
        
        public virtual void OnStateEnter(){}

        public virtual void OnStateUpdate() {}

        public virtual void OnStateExit()
        {
            ISC.Interactable.SetInteractable(true);
        }
    }
}