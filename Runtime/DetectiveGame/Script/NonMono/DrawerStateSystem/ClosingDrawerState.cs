namespace DetectiveGame.FiniteStateSystem
{
    public class ClosingDrawerState : DrawerState
    {
        public ClosingDrawerState(DrawerStateController interactableStateController) : base(interactableStateController)
        {
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            drawer.CurrentPanel.OnClosed += OnDrawerClosed;
            drawer.CurrentPanel.Close();
        }
        
        void OnDrawerClosed()
        {
            DISC.SetCurrentState(new ClosedDrawerState(DISC));
        }

        public override void OnStateExit()
        {
            drawer.CurrentPanel.OnClosed -= OnDrawerClosed;
            base.OnStateExit();
        }
    }
}