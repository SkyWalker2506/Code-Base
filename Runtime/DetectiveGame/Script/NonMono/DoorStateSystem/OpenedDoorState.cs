using System.Collections.Generic;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public class OpenedDoorState : DoorState
    {
        public OpenedDoorState(DoorStateController interactableStateController) : base(interactableStateController)
        {
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            door.DoorPanel.SetOpened();

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