using UnityEngine;

namespace StateSystem
{
    public interface IState
    {
        GameObject Owner { get; set; }
        float UpdateInteval { get; }
        IStateLogic StateLogic { get; }
        ConditionStateCouple[] ConditionStateCouples{ get; }
        IState GetAvailableState();
        void Initialize(GameObject gameObject);
    }
}