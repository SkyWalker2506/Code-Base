using UnityEngine;
using Random = System.Random;

namespace ConditionBaseStateSystem
{
    [CreateAssetMenu(menuName = "StateSystem/StateCondition/Create ChanceCondition", fileName = "ChanceCondition", order = 0)]
    public class ChanceCondition : ScriptableStateCondition
    {
        [Range(0,100)][SerializeField] private float _chance;
        private Random _random;
        public override void Initialize(IState owner)
        {
            base.Initialize(owner);
            _random = new Random();
        }

        public override bool IsConditionMet()
        {
            _random = new Random();
            int random = _random.Next(0, 100); 
            return random < _chance;
        }
    }
}