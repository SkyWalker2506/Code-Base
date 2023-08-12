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

            DISC.Interactable.SetInteraction( 
                new()
                {
                    InteractionText = "Close",
                    Interact = () => ISC.SetCurrentState(new ClosingDoorState(DISC))
                });
            DISC.Interactable.SetInteractable(true);
        }

    }
}