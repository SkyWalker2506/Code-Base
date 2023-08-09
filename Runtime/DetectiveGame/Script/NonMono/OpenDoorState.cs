using System.Collections.Generic;
using DetectiveGame.Interactable.Parts;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    
    
    public class OpenDoorState : InteractableState
    {
        private DoorPanel doorPanel;
        private Interaction closeInteraction;

        public OpenDoorState(DoorStateController interactableStateController, DoorPanel doorPanel) : base(interactableStateController)
        {
            this.doorPanel = doorPanel;
            closeInteraction = new Interaction
            {
                InteractionText = "Close",
                Interact = doorPanel.Close
            };
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            doorPanel.OnOpened += OnDoorOpened;
        }
        
        void OnDoorOpened()
        {
            InteractableStateController.Interactable.SetInteractions(new List<Interaction> { closeInteraction });
            InteractableStateController.Interactable.SetInteractable(true);
        }

    }
    /*
    public class Door : Interactable.Interactable
    {
        [SerializeField] private DoorPanel doorPanel;
        [SerializeField] private LockBase doorLock;

        [SerializeField] private bool isLockable; 
        [SerializeField] private bool initialLocked; 
        [SerializeField] private bool initialDoorOpen; 

        private Interaction openInteraction;
        private Interaction closeInteraction;
        private Interaction unlockInteraction;

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

        protected override void Initialize()
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

        void OnDoorOpened()
        {
            Interactions = new List<Interaction> { closeInteraction };
            IsInteractable = true;
        }
        
        void OnDoorClosed()
        {
            Interactions = new List<Interaction> { openInteraction };
            IsInteractable = true;
        }

        void OnDoorLocked()
        {
            Interactions = new List<Interaction> { unlockInteraction};
            IsInteractable = true;
        }
        
        void OnDoorUnLocked()
        {
            Interactions = new List<Interaction> { openInteraction};
            IsInteractable = true;
        }
    }
    */
}