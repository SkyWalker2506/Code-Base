namespace FiniteState
{
    public interface IStateController
    {
        IState CurrentState { get;}
        void SetCurrentState(IState state);
        void UpdateState();
    }
    
}