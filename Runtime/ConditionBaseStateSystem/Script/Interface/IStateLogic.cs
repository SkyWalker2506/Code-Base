namespace ConditionBaseStateSystem
{
    public interface IStateLogic
    {
        IState Owner { get; }
        void Initialize(IState owner);
        float Interval { get; }
        float LastCalledTime { get; set; }

        void TryAct();
        void Act();
        
    }
}