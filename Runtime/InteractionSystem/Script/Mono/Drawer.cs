using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace InteractionSystem
{
    public class Drawer : MonoBehaviour, IInteractable
    {
        [SerializeField] private LockBase drawerLock;
        [SerializeField] private DrawerPanel[] drawerPanels;
        [SerializeField] private bool initialLocked; 
        [FormerlySerializedAs("openDrawerIndex")]
        [Tooltip("-1 means all drawers are closed")]
        [SerializeField] private int openInitialDrawerIndex = -1; 
        private int openedDrawerIndex = -1; 
        bool isDrawerOpened => openedDrawerIndex>=0;
        
        private Interaction openInteraction;
        private Interaction openNextInteraction;
        private Interaction closeInteraction;
        private Interaction unlockInteraction;
        
        public bool IsInteractable { get; private set; }
        public Interaction[] Interactions { get; private set; }

        private void Awake()
        {
            Initialize();
        }

        private void OnEnable()
        {
            foreach (var drawerPanel in drawerPanels)
            {
                drawerPanel.OnOpened += OnDrawerOpened;
                drawerPanel.OnClosed += OnDrawerClosed;
            }
            
            if (initialLocked)
            {
                drawerLock.OnUnlocked += OnDrawerUnLocked;
            }
            IsInteractable = true;
        }

        private void OnDisable()
        {
            foreach (var drawerPanel in drawerPanels)
            {
                drawerPanel.OnOpened -= OnDrawerOpened;
                drawerPanel.OnClosed -= OnDrawerClosed;
            }
            
            if (initialLocked)
            {
                drawerLock.OnUnlocked -= OnDrawerUnLocked;
            }
            IsInteractable = false;
        }

        
        void Initialize()
        {
            if (drawerPanels.Length == 0)
            {
                return;
            }
            openInteraction = new Interaction
            {
                InteractionText = "Open",
                Interact = () => OpenDrawer(0)
            };
            openNextInteraction = new Interaction
            {
                InteractionText = "Open Next",
                Interact = () => OpenDrawer(openedDrawerIndex+1)
            };
            closeInteraction = new Interaction
            {
                InteractionText = "Close",
                Interact = CloseDrawer 
            };
            unlockInteraction = new Interaction
            {
                InteractionText = "Unlock",
                Interact = drawerLock.Unlock
            };
            
            openedDrawerIndex = Math.Clamp(openInitialDrawerIndex, -1, drawerPanels.Length);
            for (int i = 0; i < drawerPanels.Length; i++)
            {
                drawerPanels[i].Initialize(openedDrawerIndex==i);
            }

            if (!isDrawerOpened)
            {
                OnDrawerClosed();
                if (initialLocked)
                {
                    OnDrawerLocked();
                }
                else
                {
                    OnDrawerUnLocked();
                }
            }
        }
        
        public void Interact(int index)
        {
            IsInteractable = false;
            Interactions[index].Interact();
        }

        void OpenDrawer(int index)
        {
            index %= drawerPanels.Length; 
            if (isDrawerOpened)
            {
                drawerPanels[openedDrawerIndex].Close();
            }
            drawerPanels[index].Open();
            openedDrawerIndex = index;
        }
        
        private void CloseDrawer()
        {
            drawerPanels[openedDrawerIndex].Close();
            openedDrawerIndex = -1;
        }

        void OnDrawerOpened()
        {
            Interactions = new[] {openNextInteraction, closeInteraction };
            IsInteractable = true;
        }
        
        void OnDrawerClosed()
        {
            Interactions = new[] { openInteraction };
            IsInteractable = true;
        }

        void OnDrawerLocked()
        {
            Interactions = new[] { unlockInteraction};
            IsInteractable = true;
        }
        
        void OnDrawerUnLocked()
        {
            Interactions = new[] { openInteraction};
            IsInteractable = true;
        }
    }
}