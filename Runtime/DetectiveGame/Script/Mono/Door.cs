using System.Collections.Generic;
using DetectiveGame.Interactable.Parts;
using InteractionSystem;
using UnityEngine;

namespace DetectiveGame.Interactable
{
    public class Door : Interactable
    {
        [field:SerializeField] public DoorPanel DoorPanel { get; private set; }
        [field:SerializeField] public LockBase DoorLock{ get; private set; }

        [field:SerializeField] public bool IsLockable{ get; private set; } 
        [SerializeField] private bool initialLocked; 
        [SerializeField] private bool initialDoorOpen; 

        private Interaction openInteraction;
        private Interaction closeInteraction;
        private Interaction unlockInteraction;

        private void OnEnable()
        {
            DoorPanel.OnOpened += OnDoorOpened;
            DoorPanel.OnClosed += OnDoorClosed;
            if (IsLockable)
            {
                DoorLock.OnLocked += OnDoorLocked;
                DoorLock.OnUnlocked += OnDoorUnLocked;
            }
            SetInteractable(true);

        }

        private void OnDisable()
        {
            DoorPanel.OnOpened -= OnDoorOpened;
            DoorPanel.OnClosed -= OnDoorClosed;
            if (IsLockable)
            {
                DoorLock.OnLocked -= OnDoorLocked;
                DoorLock.OnUnlocked -= OnDoorUnLocked;
            }
            SetInteractable(false);

        }

        protected override void Initialize()
        {
            openInteraction = new Interaction
            {
                InteractionText = "Open",
                Interact = DoorPanel.Open
            };
            closeInteraction = new Interaction
            {
                InteractionText = "Close",
                Interact = DoorPanel.Close
            };
            unlockInteraction = new Interaction
            {
                InteractionText = "Unlock",
                Interact = DoorLock.Unlock
            };
            
            DoorPanel.Initialize(initialDoorOpen);
            if (initialDoorOpen)
            {
                OnDoorOpened();
            }
            else
            {
                OnDoorClosed();
                if (IsLockable && initialLocked)
                {
                    OnDoorLocked();
                }
                else
                {
                    OnDoorUnLocked();
                }
            }
        }

        void OnDoorOpened()
        {
            Interactions = new List<Interaction> { closeInteraction };
            SetInteractable(true);

        }
        
        void OnDoorClosed()
        {
            Interactions = new List<Interaction> { openInteraction };
            SetInteractable(true);

        }

        void OnDoorLocked()
        {
            Interactions = new List<Interaction> { unlockInteraction};
            SetInteractable(true);

        }
        
        void OnDoorUnLocked()
        {
            Interactions = new List<Interaction> { openInteraction};
            SetInteractable(true);

        }
    }
}