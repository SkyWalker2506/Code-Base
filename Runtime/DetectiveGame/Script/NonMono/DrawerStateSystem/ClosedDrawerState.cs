namespace DetectiveGame.FiniteStateSystem
{
    public class ClosedDrawerState : DrawerState
    {
        public ClosedDrawerState(DrawerStateController interactableStateController) : base(interactableStateController)
        {
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            drawer.CurrentPanel?.SetClosed();
            DSC.Interactable.SetInteraction( 
                new()
                {
                    InteractionText = "Open",
                    Interact = () =>
                    {
                        drawer.CurrentDrawerIndex = 0;
                        DSC.SetCurrentState(new OpeningDrawerState(DSC));
                    }
                });
            
            if (drawer.IsLockable)
            {
                DSC.Interactable.AddInteraction(
                    new()
                    {
                        InteractionText = "Lock",
                        Interact = () => DSC.SetCurrentState(new LockingDrawerState(DSC))
                    });
            }
            DSC.Interactable.SetInteractable(true);
        }
    }
}