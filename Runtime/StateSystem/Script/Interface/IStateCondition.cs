namespace StateSystem
{
    public interface IStateCondition
    {
        IState Owner { get; }
        bool IsConditionMet();
        void Initialize(IState owner);

    }
}