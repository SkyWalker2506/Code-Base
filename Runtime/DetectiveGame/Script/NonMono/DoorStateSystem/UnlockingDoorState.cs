namespace DetectiveGame.FiniteStateSystem
{
    public class UnlockingDoorState : DoorState
    {
        public UnlockingDoorState(DoorStateController interactableStateController) : base(interactableStateController)
        {
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            door.DoorLock.OnUnlocked += OnDoorUnlocked;
            door.DoorLock.OnUnlockFailed += OnDoorUnlockFailed;
            door.DoorLock.Unlock();
        }
        
        void OnDoorUnlocked()
        {
            DISC.SetCurrentState(new ClosedDoorState(DISC));
        }

        void OnDoorUnlockFailed()
        {
            DISC.SetCurrentState(new LockedDoorState(DISC));
        }
        
        public override void OnStateExit()
        {
            door.DoorLock.OnLocked -= OnDoorUnlocked;
            door.DoorLock.OnUnlockFailed -= OnDoorUnlockFailed;
            base.OnStateExit();
        }
    }
}