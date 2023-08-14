namespace DetectiveGame.FiniteStateSystem
{
    public class OpeningNextDrawerState : DrawerState
    {
        public OpeningNextDrawerState(DrawerStateController interactableStateController) : base(interactableStateController)
        {
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            drawer.CurrentPanel.OnClosed += CheckDrawerChanged;
            drawer.CurrentPanel.Close();
            drawer.NextPanel.OnOpened += CheckDrawerChanged;
            drawer.NextPanel.Open();
        }
        
        void CheckDrawerChanged()
        {
            if (!drawer.CurrentPanel.IsOpened && drawer.NextPanel.IsOpened)
            {
                DISC.SetCurrentState(new OpenedDrawerState(DISC));
            }
        }

        public override void OnStateExit()
        {
            drawer.CurrentPanel.OnClosed -= CheckDrawerChanged;
            drawer.NextPanel.OnOpened -= CheckDrawerChanged;
            drawer.CurrentDrawerIndex++;
            base.OnStateExit();
        }
    }
}