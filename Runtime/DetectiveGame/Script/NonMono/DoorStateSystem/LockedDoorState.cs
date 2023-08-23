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
            DSC.Interactable.SetInteraction(new()
            {
                InteractionText = "Unlock",
                Interact = () => DSC.SetCurrentState(new UnlockingDoorState(DSC))
            });
            DSC.Interactable.SetInteractable(true);
        }
    }
}