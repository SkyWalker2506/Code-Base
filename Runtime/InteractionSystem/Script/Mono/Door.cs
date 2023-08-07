using System;
using UnityEngine;

namespace InteractionSystem
{
    public class Drawer : MonoBehaviour, IInteractable
    {
        [SerializeField] private LockBase drawerLock;
        
        public bool IsInteractable { get; }
        public Interaction[] Interactions { get; }
        public void Interact(int index)
        {
            throw new NotImplementedException();
        }
    }

    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private DoorPanel doorPanel;
        [SerializeField] private LockBase doorLock;
        private Interaction openInteraction;
        private Interaction closeInteraction;
        private Interaction unlockInteraction;
        public bool IsInteractable { get; private set; }
    
        public Interaction[] Interactions { get; private set; }

        [SerializeField] private bool isLockable; 
        [SerializeField] private bool initialLocked; 
        [SerializeField] private bool initialDoorOpen; 

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
            Interactions = new[] { openInteraction };
            IsInteractable = true;
        }

        void OnDoorLocked()
        {
            Interactions = new[] { unlockInteraction};
            IsInteractable = true;
        }
        
        void OnDoorUnLocked()
        {
            Interactions = new[] { openInteraction};
            IsInteractable = true;
        }
        
    }
}