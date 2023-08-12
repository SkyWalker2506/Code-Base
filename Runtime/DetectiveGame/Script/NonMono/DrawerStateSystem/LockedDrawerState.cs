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
            DISC.Interactable.SetInteraction(new()
            {
                InteractionText = "Unlock",
                Interact = () => DISC.SetCurrentState(new UnlockingDrawerState(DISC))
            });
            DISC.Interactable.SetInteractable(true);
        }
    }
}