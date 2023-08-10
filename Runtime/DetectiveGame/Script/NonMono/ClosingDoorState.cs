using DetectiveGame.Interactable;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public class ClosingDoorState : InteractableState
    {
        private Door door;
        private Interaction openInteraction;

        public ClosingDoorState(DoorStateController interactableStateController) : base(interactableStateController)
        {
            door = interactableStateController.Door;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            door.DoorPanel.OnClosed += OnDoorClosed;
        }
        
        void OnDoorClosed()
        {
            ISC.SetCurrentState(new ClosedDoorState((DoorStateController)ISC));
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            door.DoorPanel.OnClosed -= OnDoorClosed;
        }
    }
}