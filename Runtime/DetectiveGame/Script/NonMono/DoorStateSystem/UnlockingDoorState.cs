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
            DSC.SetCurrentState(new ClosedDoorState(DSC));
        }

        void OnDoorUnlockFailed()
        {
            DSC.SetCurrentState(new LockedDoorState(DSC));
        }
        
        public override void OnStateExit()
        {
            door.DoorLock.OnLocked -= OnDoorUnlocked;
            door.DoorLock.OnUnlockFailed -= OnDoorUnlockFailed;
            base.OnStateExit();
        }
    }
}