
namespace FiniteState
{
    public interface IState 
    {
        void OnStateEnter();
        void OnStateUpdate();
        void OnStateExit();
    }

}
