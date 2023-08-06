using System;
using UnityEngine;

namespace ConditionBaseStateSystem
{
    [Serializable]
    public struct ConditionPart 
    {
        public Operator Operator;
        public bool Not;
        [SerializeField] public ScriptableStateCondition _stateCondition;

        public bool IsConditionMet()
        {
            return Not ? !_stateCondition.IsConditionMet() : _stateCondition.IsConditionMet();
        }
    }
}