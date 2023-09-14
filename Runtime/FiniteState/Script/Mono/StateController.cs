namespace FiniteState   
{
    public abstract class StateController : IStateController
    {
        public IState CurrentState { get; private set; }

        
        public void SetCurrentState(IState state)
        {
            if (CurrentState != null)
            {
                CurrentState.OnStateExit();
            }

            CurrentState = state;
            CurrentState.OnStateEnter();
        }

        public void UpdateState()
        {
            if (CurrentState != null)
            {
                CurrentState.OnStateUpdate();
            }
        }
    }
}