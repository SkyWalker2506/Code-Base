namespace DetectiveGame.FiniteStateSystem
{
    public class LockedDoorState : InteractableState
    {

        public LockedDoorState(DoorStateController interactableStateController) : base(interactableStateController)
        {
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            ISC.Interactable.SetInteraction(new()
            {
                InteractionText = "Unlock",
                Interact = () => ISC.SetCurrentState(new UnlockingDoorState((DoorStateController)ISC))
            });
            ISC.Interactable.SetInteractable(true);
        }
    }
}