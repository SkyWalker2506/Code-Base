namespace StateSystem
{
    public interface IStateController
    {
        IState State { get; set; }
        void SetCurrentState(IState state);
        void UpdateState();
    }
}