namespace DetectiveGame.FiniteStateSystem
{
    public abstract class CharacterIdleState : CharacterState
    {
        protected CharacterIdleState(InteractableStateController interactableStateController) : base(interactableStateController)
        {
        }
    }
}