using DetectiveGame.Character;

namespace DetectiveGame.FiniteStateSystem
{
    public abstract class CharacterState : InteractableState
    {
        protected CharacterStateController CSC => (CharacterStateController)ISC;
        protected readonly CharacterBase character;

        protected CharacterState(CharacterStateController interactableStateController) : base(interactableStateController)
        {
            character = interactableStateController.Character;
        }
    }
}