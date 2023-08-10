using DetectiveGame.Interactable;

namespace DetectiveGame.FiniteStateSystem
{
    public class OpeningDoorState : InteractableState
    {
        private Door door;

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
            door.DoorPanel.OnOpened -= OnDoorOpened;
            base.OnStateExit();
        }
    }
}