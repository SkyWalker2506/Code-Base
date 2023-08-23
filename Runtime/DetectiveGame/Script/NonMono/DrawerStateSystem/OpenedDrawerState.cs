using System.Collections.Generic;
using DetectiveGame.PlayerSystem;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public class OpenedDrawerState : DrawerState
    {
        public OpenedDrawerState(DrawerStateController interactableStateController) : base(interactableStateController)
        {
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            drawer.CurrentPanel.SetOpened();

            DSC.Interactable.SetInteractions(new List<Interaction> { 
                new()
                {
                    InteractionText = "Open Next",
                    Interact = () => DSC.SetCurrentState(new OpeningNextDrawerState(DSC))
                },
                new()
                {
                    InteractionText = "Close",
                    Interact = () => DSC.SetCurrentState(new ClosingDrawerState(DSC))
                }
            }
            );
            if (drawer.CurrentPanel.Inspectables.Count > 0)
            {
                drawer.CurrentPanel.SetInspectableIndex(0);
                DSC.Interactable.AddInteraction(
                    new()
                    {
                        InteractionText = "Inspect",
                        Interact = () =>
                        {
                            Player.ToggleMovementController(false);
                            DSC.SetCurrentState(new InspectingDrawerState(DSC));
                        }
                    });
            }
            ISC.Interactable.SetInteractable(true);
        }
    }
}