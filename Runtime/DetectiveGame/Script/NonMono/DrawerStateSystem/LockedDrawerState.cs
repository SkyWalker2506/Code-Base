namespace DetectiveGame.FiniteStateSystem
{
    public class LockedDrawerState : DrawerState
    {
        public LockedDrawerState(DrawerStateController interactableStateController) : base(interactableStateController)
        {
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            drawer.DrawerLock.SetLocked();
            DSC.Interactable.SetInteraction(new()
            {
                InteractionText = "Unlock",
                Interact = () => DSC.SetCurrentState(new UnlockingDrawerState(DSC))
            });
            DSC.Interactable.SetInteractable(true);
        }
    }
}