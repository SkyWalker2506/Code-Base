using System.Collections.Generic;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public class OpenedDoorState : InteractableState
    {

        public OpenedDoorState(InteractableStateController interactableStateController) : base(interactableStateController)
        {
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            ISC.Interactable.SetInteractions(new List<Interaction> { 
                new()
                {
                    InteractionText = "Close",
                    Interact = () => ISC.SetCurrentState(new ClosingDoorState((DoorStateController)ISC))
                }});
            ISC.Interactable.SetInteractable(true);
        }

    }
}