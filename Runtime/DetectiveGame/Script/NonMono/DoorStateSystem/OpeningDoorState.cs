using DetectiveGame.PlayerSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public class OpeningDoorState : DoorState
    {
        public OpeningDoorState(DoorStateController interactableStateController) : base(interactableStateController)
        {
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            door.DoorPanel.OnOpened += OnDoorOpened;
            door.DoorPanel.Open();
        }
        
        void OnDoorOpened()
        {
            ISC.SetCurrentState(new OpenedDoorState(DSC));
        }

        public override void OnStateExit()
        {
            door.DoorPanel.OnOpened -= OnDoorOpened;
            base.OnStateExit();
        }
    }
}