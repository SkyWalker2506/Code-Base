using UnityEngine;

namespace ConditionBaseStateSystem
{
    public class StateController : MonoBehaviour, IStateController
    {
        public IState CurrentState => _currentState;
        [SerializeField] private ScriptableState _initialState;
        [SerializeField] private ScriptableState _currentState;
        
        private void Awake()
        {
            SetCurrentState(_initialState);
        }

        private void Update()
        {
            UpdateState();
            CheckNextState();
        }

        public void SetCurrentState(IState state)
        {
            if (CurrentState != null)
            {
                CurrentState.OnStateExit();
            }
            _currentState = Instantiate((ScriptableState)state);
            _currentState.Initialize(gameObject);
            if (CurrentState != null)
            {
                CurrentState.OnStateEnter();
            }
            Debug.Log("Current State: " + CurrentState, gameObject);
        }
        
        
        public void UpdateState()
        {
            CurrentState.OnStateUpdate();
        }

        public void CheckNextState()
        {
            IState availableState = CurrentState.GetAvailableState();
            if (availableState != null)
            {
                SetCurrentState(availableState);
            }
        }


    }
}