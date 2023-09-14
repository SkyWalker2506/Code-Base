namespace FiniteState
{
    public abstract class State : IState
    {
        protected StateController SC { get; }
        protected State(StateController stateController)
        {
            SC = stateController;
        }
        
        public virtual void OnStateEnter(){}

        public virtual void OnStateUpdate() {}

        public virtual void OnStateExit() {}
    }
}