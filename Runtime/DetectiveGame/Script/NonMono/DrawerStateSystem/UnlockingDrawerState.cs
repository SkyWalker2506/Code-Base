﻿namespace DetectiveGame.FiniteStateSystem
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
            DSC.SetCurrentState(new ClosedDrawerState(DSC));
        }

        void OnDrawerUnlockFailed()
        {
            DSC.SetCurrentState(new LockedDrawerState(DSC));
        }
        
        public override void OnStateExit()
        {
            drawer.DrawerLock.OnLocked -= OnDrawerUnlocked;
            drawer.DrawerLock.OnUnlockFailed -= OnDrawerUnlockFailed;
            base.OnStateExit();
        }
    }
}