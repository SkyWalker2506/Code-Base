using DetectiveGame.PlayerSystem;

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
            
            DSC.Interactable.SetInteraction( 
                new()
                {
                    InteractionText = "Open",
                    Interact = () => DSC.SetCurrentState(new OpeningDoorState(DSC))
                });
            
            if (door.IsLockable)
            {
                DSC.Interactable.AddInteraction(
                    new()
                    {
                        InteractionText = "Lock",
                        Interact = () => DSC.SetCurrentState(new LockingDoorState(DSC))
                    });
            }
            DSC.Interactable.SetInteractable(true);
        }
    }
}