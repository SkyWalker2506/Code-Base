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
            drawer.CurrentPanel.OnOpened += OnDoorOpened;
            drawer.CurrentPanel.Open();
        }
        
        void OnDoorOpened()
        {
            DISC.SetCurrentState(new OpenedDrawerState(DISC));
        }

        public override void OnStateExit()
        {
            drawer.CurrentPanel.OnOpened -= OnDoorOpened;
            base.OnStateExit();
        }
    }
}