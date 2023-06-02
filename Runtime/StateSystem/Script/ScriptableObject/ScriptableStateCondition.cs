using UnityEngine;

namespace StateSystem
{
    public abstract class ScriptableStateCondition : ScriptableObject, IStateCondition
    {
        public IState Owner { get; private set;}
        public abstract bool IsConditionMet();
        
        public virtual void Initialize(IState owner)
        {
            Owner = owner;
        }
    }
}