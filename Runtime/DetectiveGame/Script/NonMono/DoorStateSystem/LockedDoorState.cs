namespace DetectiveGame.FiniteStateSystem
{
    public class LockedDoorState : DoorState
    {

        public LockedDoorState(DoorStateController interactableStateController) : base(interactableStateController)
        {
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            door.DoorLock.SetLocked();
            DISC.Interactable.SetInteraction(new()
            {
                InteractionText = "Unlock",
                Interact = () => DISC.SetCurrentState(new UnlockingDoorState(DISC))
            });
            DISC.Interactable.SetInteractable(true);
        }
    }
}