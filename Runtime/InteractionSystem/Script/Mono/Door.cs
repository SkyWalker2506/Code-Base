using System;
using UnityEngine;

namespace InteractionSystem
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private DoorPanel doorPanel;
        public bool IsInteractable { get; private set; }
        public string InteractionText { get; private set;}
        [field:SerializeField] 
        public Sprite InteractionSprite { get; private set; }
        public Action OnInteractionStarted { get; set; }
        public Action OnInteractionEnded { get; set; }

        private void OnEnable()
        {
            doorPanel.OnOpened += OnDoorOpened;
            doorPanel.OnClosed += OnDoorClosed;
        }

        private void OnDisable()
        {
            doorPanel.OnOpened -= OnDoorOpened;
            doorPanel.OnClosed -= OnDoorClosed;
        }

        public void Interact()
        {
            doorPanel.Switch();
            IsInteractable = false;
        }

        void OnDoorOpened()
        {
            InteractionText = "Close";
            IsInteractable = true;
        }
        
        void OnDoorClosed()
        {
            InteractionText = "Open";
            IsInteractable = true;
        }
    }
}