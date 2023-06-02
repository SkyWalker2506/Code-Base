using System.Timers;
using UnityEngine;
using Object = System.Object;

namespace StateSystem
{
    public class StateController : MonoBehaviour, IStateController
    {
        public IState State { get; set; }
        [SerializeField] private ScriptableState _initialState;
        [SerializeField] private ScriptableState _currentState;
        private IStateLogic _stateLogic;
        private void Awake()
        {
            SetCurrentState(_initialState);
            State = Instantiate(_initialState);
        }

        public void SetCurrentState(IState state)
        {
            CancelInvoke(nameof(UpdateState));
            State = Instantiate((ScriptableState)state);
            _currentState = (ScriptableState)State;
            Debug.Log("Current State: " + State, gameObject);
            State.Initialize(gameObject);
            _stateLogic = State.StateLogic;
            InvokeRepeating(nameof(UpdateState),State.UpdateInteval,State.UpdateInteval);
        }

        public void UpdateState()
        {
            _stateLogic.Act();
            if (State.ConditionStateCouples.Length == 0)
            {
                CancelInvoke(nameof(UpdateState));
                return;
            }
            IState availableState = State.GetAvailableState();
            if (availableState != null)
            {
                SetCurrentState(availableState);
            }
        }
    }
}