using System;
using UnityEngine;

namespace InteractionSystem
{
    public class Door : MonoBehaviour, IOpenableRotating
    {
        public string InteractionText { get; set; }
        public bool IsInteractable { get; private set; }
        [field : SerializeField] public Quaternion OpenedRotation { get; private set; }
        [field : SerializeField] public Quaternion ClosedRotation { get; private set;}
        public Action OnInteractionStarted { get; set; }
        public Action OnInteractionEnded { get; set; }
        public void Interact()
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            OnInteractionStarted?.Invoke();
            
        }

        private void OnOpened()
        {
            OnInteractionEnded?.Invoke();
            InteractionText = "Close";
        }
        
        public void Close()
        {
            OnInteractionStarted?.Invoke();
            
        }

        private void OnClosed()
        {
            OnInteractionEnded?.Invoke();
            InteractionText = "Open";
        }

    }
}