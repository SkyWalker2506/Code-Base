using System;
using UnityEngine;

namespace ConditionBaseStateSystem
{
    [CreateAssetMenu(menuName = "StateSystem/State", fileName = "State", order = 0)]
    public class ScriptableState : ScriptableObject, IState
    {
        public GameObject Owner { get; set; }
        public IStateLogic[] StateEnterLogic => _stateEnterLogic;
        public IStateLogic[] StateUpdateLogic => _stateUpdateLogic;
        public IStateLogic[] StateExitLogic => _stateExitLogic;

        public ConditionStateCouple[] ConditionStateCouples => _conditionStateCouples;
        
        [SerializeField] private ScriptableStateLogic[] _scriptableStateEnterLogic;
        [SerializeField] private ScriptableStateLogic[] _scriptableStateUpdateLogic;
        [SerializeField] private ScriptableStateLogic[] _scriptableStateExitLogic;

        [SerializeField] private ConditionStateCouple[] _conditionStateCouples;

        private IStateLogic[] _stateEnterLogic = Array.Empty<IStateLogic>();
        private IStateLogic[] _stateUpdateLogic = Array.Empty<IStateLogic>();
        private IStateLogic[] _stateExitLogic = Array.Empty<IStateLogic>();


        public void Initialize(GameObject gameObject)
        {
            Owner = gameObject;
            int logicCount = _scriptableStateEnterLogic.Length; 
            if (logicCount > 0)
            {
                _stateEnterLogic = new IStateLogic[logicCount];
                for (int i = 0; i < logicCount; i++)
                {
                    _stateEnterLogic[i] = Instantiate(_scriptableStateEnterLogic[i]);
                    _stateEnterLogic[i].Initialize(this);
                }
            }
            
            logicCount = _scriptableStateUpdateLogic.Length; 
            if (logicCount > 0)
            {
                _stateUpdateLogic = new IStateLogic[logicCount];
                for (int i = 0; i < logicCount; i++)
                {
                    _stateUpdateLogic[i] = Instantiate(_scriptableStateUpdateLogic[i]);
                    _stateUpdateLogic[i].Initialize(this);
                }
            }
            
            logicCount = _scriptableStateExitLogic.Length; 
            if (logicCount > 0)
            {
                _stateExitLogic = new IStateLogic[logicCount];
                for (int i = 0; i < logicCount; i++)
                {
                    _stateExitLogic[i] = Instantiate(_scriptableStateExitLogic[i]);
                    _stateExitLogic[i].Initialize(this);
                }
            }
            
            foreach (ConditionStateCouple conditionStateCouple in ConditionStateCouples)
            {
                conditionStateCouple.Initialize(this);
            }
        }
        
        public IState GetAvailableState()
        {
            foreach (ConditionStateCouple conditionStateCouple in ConditionStateCouples)
            {
                IState availableState = conditionStateCouple.GetAvailableState();
                if (availableState != null)
                {
                    return availableState;
                }
            }
            return null;
        }

        public void OnStateEnter()
        {
            foreach (IStateLogic logic in StateEnterLogic)
            {
                logic.Act();
            }
        }

        public void OnStateUpdate()
        {
            foreach (IStateLogic logic in StateUpdateLogic)
            {
                logic.TryAct();
            }
        }

        public void OnStateExit()
        {
            foreach (IStateLogic logic in StateExitLogic)
            {
                logic.Act();
            }
        }
    }
}