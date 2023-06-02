using UnityEngine;

namespace StateSystem
{
    [CreateAssetMenu(menuName = "StateSystem/StateLogic/Create DebugIntLogic", fileName = "DebugIntLogic", order = 0)]
    public class DebugIntLogic : ScriptableStateLogic
    {
        
        [SerializeField] private int _value;
        public override void Act()
        {
            Debug.Log(_value);
        }
    }
}