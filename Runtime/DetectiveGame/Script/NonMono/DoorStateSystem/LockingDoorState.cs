namespace DetectiveGame.FiniteStateSystem
{
    public class LockingDoorState : DoorState
    {
        public LockingDoorState(DoorStateController interactableStateController) : base(interactableStateController)
        {
        }
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            door.DoorLock.OnLocked += OnDoorLocked;
            door.DoorLock.Lock();
        }
        
        void OnDoorLocked()
        {
            DISC.SetCurrentState(new LockedDoorState(DISC));
        }

        public override void OnStateExit()
        {
            door.DoorLock.OnLocked -= OnDoorLocked;
            base.OnStateExit();
        }
    }
}