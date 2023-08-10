using DetectiveGame.Interactable;

namespace DetectiveGame.FiniteStateSystem
{
    public class UnlockingDoorState : InteractableState
    {
        private Door door;

        public UnlockingDoorState(DoorStateController interactableStateController) : base(interactableStateController)
        {
            door = interactableStateController.Door;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            door.DoorLock.OnUnlocked += OnDoorUnlocked;
        }
        
        void OnDoorUnlocked()
        {
            ISC.SetCurrentState(new ClosedDoorState((DoorStateController)ISC));
        }

        public override void OnStateExit()
        {
            door.DoorLock.OnLocked -= OnDoorUnlocked;
            base.OnStateExit();
        }
    }
}