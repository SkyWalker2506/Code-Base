using UnityEngine;

namespace StateSystem
{
    public interface IState
    {
        GameObject Owner { get; set; }
        IStateLogic[] StateEnterLogic { get; }
        IStateLogic[] StateUpdateLogic { get; }
        IStateLogic[] StateExitLogic { get; }
        ConditionStateCouple[] ConditionStateCouples{ get; }
        void Initialize(GameObject gameObject);
        IState GetAvailableState();
        void OnStateEnter();
        void OnStateUpdate();
        void OnStateExit();
    }
}