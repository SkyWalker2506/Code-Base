using UnityEngine;
using UnityEngine.Serialization;

namespace ConditionBaseStateSystem
{
    public abstract class ScriptableStateLogic : ScriptableObject, IStateLogic
    {
        public IState Owner { get; set;}
        public float Interval => _interval;
        public float LastCalledTime { get; set; }
        [SerializeField][Min(.1f)] private float _interval = 1;
        private bool ReadyForActing => _passedTime >= Interval;
        private float _passedTime => Time.time - LastCalledTime;


        public virtual void Initialize(IState owner)
        {
            Owner = owner;
        }

        public void TryAct()
        {
            if (ReadyForActing)
            {
                Act();
                LastCalledTime = Time.time;
            }
        }
        
        public abstract void Act();

    }
}