namespace DetectiveGame.FiniteStateSystem
{
    public abstract class CharacterState : InteractableState
    {
        protected CharacterState(InteractableStateController interactableStateController) : base(interactableStateController)
        {
        }
    }
}