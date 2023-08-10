using DetectiveGame.Interactable;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public class DoorStateController : InteractableStateController
    {
        public Door Door { get; }

        public DoorStateController(IInteractable interactable) : base(interactable)
        {
            Door = (Door)interactable;
            Initialize();
        }

        void Initialize()
        {
            if (Door.InitialDoorOpen)
            {
                SetCurrentState(new OpenedDoorState(this));
            }
            else
            {
                SetCurrentState(new ClosedDoorState(this));

                if (Door.IsLockable && Door.InitialLocked)
                {
                    SetCurrentState(new LockedDoorState(this));
                }
            }
        }
        
    }
}