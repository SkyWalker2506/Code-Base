namespace DetectiveGame.FiniteStateSystem
{
    public class OpeningDrawerState : DrawerState
    {
        public OpeningDrawerState(DrawerStateController interactableStateController) : base(interactableStateController)
        {
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            drawer.CurrentPanel.OnOpened += OnDrawerOpened;
            drawer.CurrentPanel.Open();
        }
        
        void OnDrawerOpened()
        {
            DISC.SetCurrentState(new OpenedDrawerState(DISC));
        }

        public override void OnStateExit()
        {
            drawer.CurrentPanel.OnOpened -= OnDrawerOpened;
            base.OnStateExit();
        }
    }
}