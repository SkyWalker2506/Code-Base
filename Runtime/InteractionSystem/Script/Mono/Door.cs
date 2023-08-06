using System;
using UnityEngine;

namespace InteractionSystem
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private DoorPanel doorPanel;
        public bool IsInteractable { get; private set; }
        public Interaction[] Interactions { get; private set; }
        public string InteractionText { get; private set;}
        [field:SerializeField] public Sprite InteractionSprite { get; private set; }
        [SerializeField] private bool initialDoorOpen; 

        public Action OnInteractionStarted { get; set; }
        public Action OnInteractionEnded { get; set; }

        private void Awake()
        {
            doorPanel.Initialize(initialDoorOpen);
            Interactions = new Interaction[]
            {
                new Interaction
                {
                 InteractionText = InteractionText,
                 InteractionSprite = InteractionSprite,
                 OnInteractionStarted = OnInteractionStarted,
                 OnInteractionEnded = OnInteractionEnded
                }
            };
        }

        private void OnEnable()
        {
            doorPanel.OnOpened += OnDoorOpened;
            doorPanel.OnClosed += OnDoorClosed;
            IsInteractable = true;
            InteractionText = doorPanel.IsOpened?"Close":"Open";
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