namespace StateSystem
{
    public interface IStateCondition
    {
        IState Owner { get; }
        float CheckInterval { get; }
        float LastCheckedTime { get; }
        bool IsConditionMet();
        void Initialize(IState owner);
    }
    
}