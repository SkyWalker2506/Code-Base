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
            if (Drawer.OpenInitialDrawerIndex>=0)
            {
                SetCurrentState(new OpenedDrawerState(this));
            }
            else
            {
                SetCurrentState(new ClosedDrawerState(this));

                if (Drawer.IsLockable && Drawer.InitialLocked)
                {
                    SetCurrentState(new LockedDrawerState(this));
                }
            }
        }
 
    }
}