using UnityEngine;

namespace StateSystem
{
    [CreateAssetMenu(menuName = "StateSystem/Create Condition Combiner", fileName = "ConditionCombiner", order = 0)]

    public class ConditionCombiner : ScriptableStateCondition, IStateCondition
    {
        [SerializeField] private ConditionPart[] _conditionParts;
        public override void Initialize(IState owner)
        {
            base.Initialize(owner);
            foreach (var item in _conditionParts)
            {
                item._stateCondition.Initialize(owner);
            }
        }
        public override bool IsConditionMet()
        {
            bool isConditionMet = true;
            for (int i = 0; i < _conditionParts.Length; i++)
            {
                ConditionPart part = _conditionParts[i];
                if (part.Operator == Operator.And)
                {
                    isConditionMet &= part.IsConditionMet();
                }
                else if (part.Operator == Operator.Or)
                {
                    isConditionMet |= part.IsConditionMet();
                }
            }
            
            return isConditionMet;
        }
    }
}