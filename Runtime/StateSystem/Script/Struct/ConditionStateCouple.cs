using System;

namespace StateSystem
{
    [Serializable]
    public struct ConditionStateCouple
    {
        public ScriptableStateCondition[] StateConditions;
        public ScriptableState[] States;

        public void Initialize(IState state)
        {
            foreach (ScriptableStateCondition stateCondition in StateConditions)
            {
                stateCondition.Initialize(state);
            }
        }
        
        public IState GetAvailableState()
        {
            foreach (ScriptableStateCondition stateCondition in StateConditions)
            {
                if (stateCondition.IsConditionMet())
                {
                    return GetRandomState();
                }
            }

            return null;
        }

        private IState GetRandomState()
        {
            return States.Length > 0?States[new Random().Next(0, States.Length)]:null;
        }
    }
}