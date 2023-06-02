using UnityEngine;

namespace StateSystem
{
    public abstract class ScriptableStateLogic : ScriptableObject, IStateLogic
    {
        public IState Owner { get; set;}
        public virtual void Initialize(IState owner)
        {
            Owner = owner;
        }

        public abstract void Act();
    }
}