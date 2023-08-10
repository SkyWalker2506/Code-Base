using System.Collections.Generic;
using DetectiveGame.Interactable;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public class ClosedDoorState : InteractableState
    {
        private Door door;

        public ClosedDoorState(DoorStateController interactableStateController) : base(interactableStateController)
        {
            door = interactableStateController.Door;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            ISC.Interactable.SetInteraction( 
                new()
                {
                    InteractionText = "Open",
                    Interact = () => ISC.SetCurrentState(new OpeningDoorState((DoorStateController)ISC))
                });
            
            if (door.IsLockable)
            {
                ISC.Interactable.AddInteraction(
                    new()
                    {
                        InteractionText = "Lock",
                        Interact = () => ISC.SetCurrentState(new OpeningDoorState((DoorStateController)ISC))
                    });
            }
            ISC.Interactable.SetInteractable(true);
        }
    }
}