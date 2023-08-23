using DetectiveGame.Interactable;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public abstract class DrawerState : InteractableState
    {
        protected DrawerStateController DSC => (DrawerStateController)ISC;
        protected readonly Drawer drawer;

        protected DrawerState(DrawerStateController interactableStateController) : base(interactableStateController)
        {
            drawer = interactableStateController.Drawer;
        }
    }
}