using UnityEngine;

namespace ConditionBaseStateSystem
{
    [CreateAssetMenu(menuName = "StateSystem/StateLogic/Create DisableLogic", fileName = "DisableLogic", order = 0)]
    public class DisableLogic : ScriptableStateLogic
    {
        public override void Act()
        {
            Owner.Owner.SetActive(false);   
        }
    }
}