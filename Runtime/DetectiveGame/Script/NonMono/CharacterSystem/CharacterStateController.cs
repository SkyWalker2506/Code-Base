using DetectiveGame.Character;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public abstract class CharacterStateController : InteractableStateController
    {
        public CharacterBase Character{ get; }

        protected CharacterStateController(IInteractable interactable) : base(interactable)
        {
            Character = (CharacterBase)interactable;
        }
    }
}