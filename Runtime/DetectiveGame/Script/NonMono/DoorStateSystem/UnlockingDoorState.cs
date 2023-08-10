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
            door.DoorLock.Unlock();
        }
        
        void OnDoorUnlocked()
        {
            DISC.SetCurrentState(new ClosedDoorState(DISC));
        }

        public override void OnStateExit()
        {
            door.DoorLock.OnLocked -= OnDoorUnlocked;
            base.OnStateExit();
        }
    }
}