using DetectiveGame.Interactable;

namespace DetectiveGame.FiniteStateSystem
{
    public class LockingDoorState : InteractableState
    {
        private Door door;

        public LockingDoorState(DoorStateController interactableStateController) : base(interactableStateController)
        {
            door = interactableStateController.Door;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            door.DoorLock.OnLocked += OnDoorLocked;
        }
        
        void OnDoorLocked()
        {
            ISC.SetCurrentState(new LockedDoorState((DoorStateController)ISC));
        }

        public override void OnStateExit()
        {
            door.DoorLock.OnLocked -= OnDoorLocked;
            base.OnStateExit();
        }
    }
}