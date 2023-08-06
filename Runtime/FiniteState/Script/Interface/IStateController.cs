namespace FiniteState
{
    public interface IStateController
    {
        IState CurrentState { get;}
        void SetCurrentState(IState state);
        void UpdateState();
    }
    
    public class DoorStateController : IStateController
    {
        public IState CurrentState { get; private set; }
        public void SetCurrentState(IState state)
        {
            CurrentState = state;
        }

        public void UpdateState()
        {
            throw new System.NotImplementedException();
        }
    }
}