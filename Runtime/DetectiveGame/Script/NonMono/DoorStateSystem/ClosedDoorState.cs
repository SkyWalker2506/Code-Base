namespace DetectiveGame.FiniteStateSystem
{
    public class ClosedDoorState : DoorState
    {
        public ClosedDoorState(DoorStateController interactableStateController) : base(interactableStateController)
        {
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            door.DoorPanel.SetClosed();
            
            DISC.Interactable.SetInteraction( 
                new()
                {
                    InteractionText = "Open",
                    Interact = () => DISC.SetCurrentState(new OpeningDoorState(DISC))
                });
            
            if (door.IsLockable)
            {
                DISC.Interactable.AddInteraction(
                    new()
                    {
                        InteractionText = "Lock",
                        Interact = () => DISC.SetCurrentState(new LockingDoorState(DISC))
                    });
            }
            DISC.Interactable.SetInteractable(true);
        }
    }
}