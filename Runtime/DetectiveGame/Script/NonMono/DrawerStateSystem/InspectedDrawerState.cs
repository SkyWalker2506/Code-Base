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
            DSC.Interactable.SetInteraction(new Interaction
            {
                InteractionText = "Stop Inspection",
                Interact = () => DSC.SetCurrentState(new StopInspectingDrawerState(DSC))
            });
            Input.OnLeft += InspectPrevious;
            Input.OnRight += InspectNext;
            DSC.Interactable.AddInteractions(drawer.CurrentPanel.InspectedObject.Interactions);
            if (drawer.CurrentPanel.InspectedObject.transform.TryGetComponent(out ICollectable collectable))
            {
                collectable.OnCollected += () =>
                {
                    drawer.CurrentPanel.Inspectables.Remove(drawer.CurrentPanel.InspectedObject);
                    collectable.OnCollected = null;
                    InspectNext();
                };
            }
            drawer.CurrentPanel.InspectedObject.OnInteracted += OnInspectedAction;
            DSC.Interactable.SetInteractable(true);
        }

        void InspectNext()
        {
            drawer.CurrentPanel.InspectNext();
            DSC.SetCurrentState(new InspectingDrawerState(DSC));
        }
        
        void InspectPrevious()
        {
            drawer.CurrentPanel.InspectPrev();
            DSC.SetCurrentState(new InspectingDrawerState(DSC));
        }

        void OnInspectedAction()
        {
            DSC.SetCurrentState(new InspectingDrawerState(DSC));
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            Input.OnLeft -= InspectPrevious;
            Input.OnRight -= InspectNext;
            drawer.CurrentPanel.InspectedObject.OnInteracted -= OnInspectedAction;
        }
    }
}