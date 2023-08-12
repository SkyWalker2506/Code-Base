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
            drawer.DrawerLock.Unlock();
        }
        
        void OnDrawerUnlocked()
        {
            DISC.SetCurrentState(new ClosedDrawerState(DISC));
        }

        public override void OnStateExit()
        {
            drawer.DrawerLock.OnLocked -= OnDrawerUnlocked;
            base.OnStateExit();
        }
    }
}