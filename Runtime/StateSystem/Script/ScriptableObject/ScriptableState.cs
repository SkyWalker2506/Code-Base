using UnityEngine;

namespace StateSystem
{
    [CreateAssetMenu(menuName = "StateSystem/State", fileName = "State", order = 0)]
    public class ScriptableState : ScriptableObject, IState
    {
        public GameObject Owner { get; set; }

        public IStateLogic StateLogic
        {
            get
            {
                if (_stateLogic == null)
                {
                    _stateLogic = Instantiate(_scriptableStateLogic);
                    _stateLogic.Initialize(this);
                }
                return _stateLogic;
            }
        }
        public ConditionStateCouple[] ConditionStateCouples => _conditionStateCouples;
        public float UpdateInteval => _updateInteval;
        [SerializeField] private ScriptableStateLogic _scriptableStateLogic;
        [SerializeField][Min(.1f)] private float _updateInteval = 1;
        [SerializeField] private ConditionStateCouple[] _conditionStateCouples;
        
        private IStateLogic _stateLogic;


        public void Initialize(GameObject gameObject)
        {
            Owner = gameObject;
            foreach (ConditionStateCouple _conditionStateCouple in _conditionStateCouples)
            {
                _conditionStateCouple.Initialize(this);
            }
        }
        
        public IState GetAvailableState()
        {
            foreach (ConditionStateCouple conditionStateCouple in ConditionStateCouples)
            {
                IState availableState = conditionStateCouple.GetAvailableState();
                if (availableState != null)
                {
                    return availableState;
                }
            }
            return null;
        }
    }
}