using System;
using UnityEngine;
using Random = System.Random;

namespace StateSystem
{
    [Serializable]
    public class ConditionStateCouple
    {
        [SerializeField] private ScriptableStateCondition[] _stateConditions;
        [SerializeField] private ScriptableState[] _states;

        private ScriptableStateCondition[] _stateConditionInstances;

        public void Initialize(IState state)
        {
            _stateConditionInstances = new ScriptableStateCondition[_stateConditions.Length];

            for (int i = 0; i < _stateConditions.Length; i++)
            {
                _stateConditionInstances[i] = UnityEngine.Object.Instantiate(_stateConditions[i]);
            }

            foreach (ScriptableStateCondition stateCondition in _stateConditionInstances)
            {
                stateCondition.Initialize(state);
            }
        }

        public IState GetAvailableState()
        {
            if (_stateConditionInstances == null)
            {
                return null;
            }

            foreach (ScriptableStateCondition stateCondition in _stateConditionInstances)
            {
                if (!stateCondition.ReadyForChecking)
                {
                    continue;
                }

                stateCondition.LastCheckedTime = Time.time;
                if (stateCondition.IsConditionMet())
                {
                    return GetRandomState();
                }
            }

            return null;
        }

        private IState GetRandomState()
        {
            return _states.Length > 0 ? _states[new Random().Next(0, _states.Length)] : null;
        }
    }
}