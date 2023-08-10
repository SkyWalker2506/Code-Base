using DetectiveGame.Interactable;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{

    public class DoorStateController : InteractableStateController
    {
        public Door Door { get; }

        public DoorStateController(IInteractable interactable, Door door) : base(interactable)
        {
            Door = door;
        }
    }
}