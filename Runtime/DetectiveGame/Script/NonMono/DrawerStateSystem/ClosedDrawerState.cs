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
            
            drawer.CurrentPanel.SetClosed();
            
            DISC.Interactable.SetInteraction( 
                new()
                {
                    InteractionText = "Open",
                    Interact = () => DISC.SetCurrentState(new OpenedDrawerState(DISC))
                });
            
            if (drawer.IsLockable)
            {
                DISC.Interactable.AddInteraction(
                    new()
                    {
                        InteractionText = "Lock",
                        Interact = () => DISC.SetCurrentState(new LockingDrawerState(DISC))
                    });
            }
            DISC.Interactable.SetInteractable(true);
        }
    }
}