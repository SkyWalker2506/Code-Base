using DetectiveGame.Interactable;

namespace DetectiveGame.FiniteStateSystem
{
    public abstract class DoorState : InteractableState
    {
        protected DoorStateController DISC => (DoorStateController)ISC;
        protected readonly Door door;

        protected DoorState(DoorStateController  interactableStateController) : base(interactableStateController)
        {
            door = interactableStateController.Door;
        }
    }
}