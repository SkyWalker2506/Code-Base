using System;
using UnityEngine;

namespace InteractionSystem
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private DoorPanel doorPanel;
        [SerializeField] private LockBase doorLock;
        private Interaction openInteraction;
        private Interaction closeInteraction;
        private Interaction unlockInteraction;
        private Interaction lockInteraction;
        public bool IsInteractable { get; private set; }
    
        public Interaction[] Interactions { get; private set; }

        [SerializeField] private bool initialDoorOpen; 
        [SerializeField] private bool isLockable; 
        [SerializeField] private bool initialLocked; 

        private void Awake()
        {
            Initialize();
        }

        private void OnEnable()
        {
            doorPanel.OnOpened += OnDoorOpened;
            doorPanel.OnClosed += OnDoorClosed;
            if (isLockable)
            {
                doorLock.OnLocked += OnDoorLocked;
                doorLock.OnUnlocked += OnDoorUnLocked;
            }
            IsInteractable = true;
        }

        private void OnDisable()
        {
            doorPanel.OnOpened -= OnDoorOpened;
            doorPanel.OnClosed -= OnDoorClosed;
            if (isLockable)
            {
                doorLock.OnLocked -= OnDoorLocked;
                doorLock.OnUnlocked -= OnDoorUnLocked;
            }
            IsInteractable = false;
        }

        void Initialize()
        {
            openInteraction = new Interaction
            {
                InteractionText = "Open",
                Interact = doorPanel.Open
            };
            closeInteraction = new Interaction
            {
                InteractionText = "Close",
                Interact = doorPanel.Close
            };
            unlockInteraction = new Interaction
            {
                InteractionText = "Unlock",
                Interact = doorLock.Unlock
            };
            lockInteraction = new Interaction
            {
                InteractionText = "lock",
                Interact = doorLock.Lock
            };
            
            doorPanel.Initialize(initialDoorOpen);
            if (initialDoorOpen)
            {
                OnDoorOpened();
            }
            else
            {
                OnDoorClosed();
                if (isLockable && initialLocked)
                {
                    OnDoorLocked();
                }
                else
                {
                    OnDoorUnLocked();
                }
            }
        }

        public void Interact(int index)
        {
            IsInteractable = false;
            Interactions[index].Interact();
        }

        void OnDoorOpened()
        {
            Interactions = new[] { closeInteraction };
            IsInteractable = true;
        }
        
        void OnDoorClosed()
        {
            Interactions = new[] { openInteraction , lockInteraction};
            IsInteractable = true;
        }

        void OnDoorLocked()
        {
            Interactions = new[] { unlockInteraction};
            IsInteractable = true;
        }
        
        void OnDoorUnLocked()
        {
            Interactions = new[] { openInteraction, lockInteraction};
            IsInteractable = true;
        }
        
    }
}