namespace DetectiveGame.FiniteStateSystem
{
    public class UnlockingDrawerState : DrawerState
    {
        public UnlockingDrawerState(DrawerStateController interactableStateController) : base(interactableStateController)
        {
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            drawer.DrawerLock.OnUnlocked += OnDrawerUnlocked;
            drawer.DrawerLock.OnUnlockFailed += OnDrawerUnlockFailed;
            drawer.DrawerLock.Unlock();
        }
        
        void OnDrawerUnlocked()
        {
            DISC.SetCurrentState(new ClosedDrawerState(DISC));
        }

        void OnDrawerUnlockFailed()
        {
            DISC.SetCurrentState(new LockedDrawerState(DISC));
        }
        
        public override void OnStateExit()
        {
            drawer.DrawerLock.OnLocked -= OnDrawerUnlocked;
            drawer.DrawerLock.OnUnlockFailed -= OnDrawerUnlockFailed;
            base.OnStateExit();
        }
    }
}