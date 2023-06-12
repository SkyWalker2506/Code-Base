using UnityEngine;

namespace StateSystem
{
    [CreateAssetMenu(menuName = "StateSystem/StateLogic/Create DebugLogic", fileName = "DebugLogic", order = 0)]
    public class DebugLogic : ScriptableStateLogic
    {
        [SerializeField] private string _value;

        public override void Act()
        {
            Debug.Log(_value);
        }
    }
}