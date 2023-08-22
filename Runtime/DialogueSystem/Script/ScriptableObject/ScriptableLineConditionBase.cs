using UnityEngine;

namespace DialogueSystem
{
    public abstract class ScriptableLineConditionBase : ScriptableObject, ILineCondition
    {
        public abstract bool IsLineUsable();
    }
}