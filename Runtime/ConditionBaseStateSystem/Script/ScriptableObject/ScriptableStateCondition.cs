using UnityEngine;

namespace ConditionBaseStateSystem
{
    public abstract class ScriptableStateCondition : ScriptableObject, IStateCondition
    {
        public IState Owner { get; protected set;}
        public virtual float CheckInterval => checkInterval;
        public virtual float LastCheckedTime { get; set; } = 0;
        public bool ReadyForChecking => _passedTime > checkInterval;
        [SerializeField] private float checkInterval;
        private float _passedTime => Time.time - LastCheckedTime;
        
        public abstract bool IsConditionMet();
        public virtual void Initialize(IState owner)
        {
            Owner = owner;
        }
    }
}