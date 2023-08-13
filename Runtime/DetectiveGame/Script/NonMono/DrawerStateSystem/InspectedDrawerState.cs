using DetectiveGame.PlayerSystem;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public class InspectedDrawerState : DrawerState
    {
        public InspectedDrawerState(DrawerStateController interactableStateController) : base(interactableStateController)
        {
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            DISC.Interactable.SetInteraction(new Interaction
            {
                InteractionText = "Close Inspection",
                Interact = () => DISC.SetCurrentState(new StopInspectingDrawerState(DISC))
            });
            DISC.Interactable.AddInteractions(drawer.CurrentPanel.InspectedObject.Interactions);
            Input.OnLeft += InspectPrevious;
            Input.OnRight += InspectNext;
            DISC.Interactable.SetInteractable(true);
        }

        void InspectNext()
        {
            drawer.CurrentPanel.InspectNext();
            DISC.SetCurrentState(new InspectingDrawerState(DISC));
        }
        
        void InspectPrevious()
        {
            drawer.CurrentPanel.InspectPrev();
            DISC.SetCurrentState(new InspectingDrawerState(DISC));
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            Input.OnLeft -= InspectPrevious;
            Input.OnRight -= InspectNext;
        }
    }
}