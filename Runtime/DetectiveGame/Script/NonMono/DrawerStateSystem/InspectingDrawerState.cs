namespace DetectiveGame.FiniteStateSystem
{
    public class InspectingDrawerState : DrawerState
    {
        public InspectingDrawerState(DrawerStateController interactableStateController) : base(interactableStateController)
        {
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            drawer.CurrentPanel.OnInspect += OnInspect;
            drawer.CurrentPanel.Inspect();
        }
        
        void OnInspect()
        {
            DISC.SetCurrentState(new InspectedDrawerState(DISC));
        }

        public override void OnStateExit()
        {
            drawer.CurrentPanel.OnInspect -= OnInspect;
            base.OnStateExit();
        }
    }
}