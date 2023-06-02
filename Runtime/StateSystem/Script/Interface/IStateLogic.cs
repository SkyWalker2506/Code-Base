namespace StateSystem
{
    public interface IStateLogic
    {
        IState Owner { get; }
        void Initialize(IState owner);
        void Act();
        
    }
}