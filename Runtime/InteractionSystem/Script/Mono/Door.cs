using System;
using UnityEngine;

namespace InteractionSystem
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private DoorPanel doorPanel;
        public bool IsInteractable { get; private set; }
        [SerializeField] private InteractionUIData interactionUIData; 
        public string InteractionText { get; set; }

        public IInteraction[] Interactions { get; private set; }

        [SerializeField] private bool initialDoorOpen; 

        public Action OnInteractionStarted { get; set; }
        public Action OnInteractionEnded { get; set; }

        private void Awake()
        {
            doorPanel.Initialize(initialDoorOpen);
            Interactions = new IInteraction[]
            {
                new RotateInteraction
                { 
                    InteractionUIData =interactionUIData,
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

        public void Interact(int index)
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