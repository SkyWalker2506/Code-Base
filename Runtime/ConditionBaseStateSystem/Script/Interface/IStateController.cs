namespace ConditionBaseStateSystem
{
    public interface IStateController
    {
        IState CurrentState { get;}
        void SetCurrentState(IState state);
        void CheckNextState();
        void UpdateState();
    }
}