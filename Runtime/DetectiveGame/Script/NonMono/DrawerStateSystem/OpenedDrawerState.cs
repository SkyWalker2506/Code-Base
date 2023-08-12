using System.Collections.Generic;
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

            DISC.Interactable.SetInteractions(new List<Interaction> { 
                new()
                {
                    InteractionText = "Open Next",
                    Interact = () => DISC.SetCurrentState(new ClosingDrawerState(DISC))
                },
                new()
                {
                InteractionText = "Close",
                Interact = () => DISC.SetCurrentState(new ClosingDrawerState(DISC))
                }
            }
            );
            ISC.Interactable.SetInteractable(true);
        }
    }
}