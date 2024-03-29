﻿namespace DetectiveGame.FiniteStateSystem
{
    public class LockingDrawerState : DrawerState
    {
        public LockingDrawerState(DrawerStateController interactableStateController) : base(interactableStateController)
        {
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            drawer.DrawerLock.OnLocked += OnDrawerLocked;
            drawer.DrawerLock.Lock();
        }
        
        void OnDrawerLocked()
        {
            DSC.SetCurrentState(new LockedDrawerState(DSC));
        }

        public override void OnStateExit()
        {
            drawer.DrawerLock.OnLocked -= OnDrawerLocked;
            base.OnStateExit();
        }
        
    }
}