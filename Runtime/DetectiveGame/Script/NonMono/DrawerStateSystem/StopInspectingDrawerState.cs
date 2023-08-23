using DetectiveGame.PlayerSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public class StopInspectingDrawerState : DrawerState
    {
        public StopInspectingDrawerState(DrawerStateController interactableStateController) : base(interactableStateController)
        {
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            drawer.CurrentPanel.OnInspectEnded += OnInspectEnded;
            drawer.CurrentPanel.StopInspect();
        }
        
        void OnInspectEnded()
        {
            Player.ToggleMovementController(true);
            DSC.SetCurrentState(new OpenedDrawerState(DSC));
        }

        public override void OnStateExit()
        {
            drawer.CurrentPanel.OnInspect -= OnInspectEnded;
            base.OnStateExit();
        }
    }
}