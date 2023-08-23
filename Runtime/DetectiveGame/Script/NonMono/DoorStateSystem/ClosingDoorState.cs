using DetectiveGame.Interactable;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public class ClosingDoorState : DoorState
    {
        public ClosingDoorState(DoorStateController interactableStateController) : base(interactableStateController)
        {
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            door.DoorPanel.OnClosed += OnDoorClosed;
            door.DoorPanel.Close();
        }
        
        void OnDoorClosed()
        {
            DSC.SetCurrentState(new ClosedDoorState(DSC));
        }

        public override void OnStateExit()
        {
            door.DoorPanel.OnClosed -= OnDoorClosed;
            base.OnStateExit();
        }
    }
}