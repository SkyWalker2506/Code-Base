using System;
using CodeBase.Core;
using FiniteState;
using UnityEngine;

namespace InteractionSystem
{
    public interface IInteractable : IHaveTransform
    {
        bool IsInteractable{ get; }
        Interaction[] Interactions{ get; }
        void Interact();
    }

    public struct Interaction
    {
        public string InteractionText { get; set;}
        public Sprite InteractionSprite { get; set;}
        public Action OnInteractionStarted{ get; set; }
        public Action OnInteractionEnded{ get; set; } 
    }
    
    public class DoorStateController : IStateController
    {
        public IState CurrentState { get; }
        public void SetCurrentState(IState state)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateState()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class DoorOpenedState : IState
    {
        public IStateController StateController { get; }
        public void OnStateEnter()
        {
            throw new System.NotImplementedException();
        }

        public void OnStateUpdate()
        {
            throw new System.NotImplementedException();
        }

        public void OnStateExit()
        {
            throw new System.NotImplementedException();
        }
    }
}