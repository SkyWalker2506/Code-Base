using DetectiveGame.Interactable;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public class OpeningDoorState : InteractableState
    {
        private Door door;
        private Interaction closeInteraction;

        public OpeningDoorState(DoorStateController interactableStateController) : base(interactableStateController)
        {
            door = interactableStateController.Door;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            door.DoorPanel.OnOpened += OnDoorOpened;
        }
        
        void OnDoorOpened()
        {
            ISC.SetCurrentState(new OpenedDoorState((DoorStateController)ISC));
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            door.DoorPanel.OnOpened -= OnDoorOpened;
        }
    }
}