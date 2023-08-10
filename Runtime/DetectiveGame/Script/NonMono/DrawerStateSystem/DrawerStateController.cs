using DetectiveGame.Interactable;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public class DrawerStateController : InteractableStateController
    {
        public Drawer Drawer { get; }

        public DrawerStateController(IInteractable interactable) : base(interactable)
        {
            Drawer = (Drawer)interactable;
            Initialize();
        }

        void Initialize()
        {
        }
        
 
    }
}