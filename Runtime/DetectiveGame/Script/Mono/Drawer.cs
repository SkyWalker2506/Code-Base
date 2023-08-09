using System;
using System.Collections.Generic;
using DetectiveGame.Interactable.Parts;
using InteractionSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace DetectiveGame.Interactable
{
    public class Drawer : Interactable
    {
        [SerializeField] private LockBase drawerLock;
        [SerializeField] private DrawerPanel[] drawerPanels;
        DrawerPanel currentPanel => drawerPanels[openedDrawerIndex];

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
        private Interaction inspectInteraction;
        private Interaction focusNextInteraction;
        private Interaction closeInspectInteraction;
        private Interaction focusInteraction;
        private Interaction unfocusInteraction;
        
        private void OnEnable()
        {
            foreach (var drawerPanel in drawerPanels)
            {
                drawerPanel.OnOpened += OnDrawerOpened;
                drawerPanel.OnClosed += OnDrawerClosed;
                drawerPanel.OnInspect += OnInspected;
                drawerPanel.OnInspectEnded += OnInspectEnded;
            }
            
            if (initialLocked)
            {
                drawerLock.OnUnlocked += OnDrawerUnLocked;
            }
            SetInteractable(true);

        }

        private void OnDisable()
        {
            foreach (var drawerPanel in drawerPanels)
            {
                drawerPanel.OnOpened -= OnDrawerOpened;
                drawerPanel.OnClosed -= OnDrawerClosed;
                drawerPanel.OnInspect -= OnInspected;
                drawerPanel.OnInspectEnded -= OnInspectEnded;
            }
            
            if (initialLocked)
            {
                drawerLock.OnUnlocked -= OnDrawerUnLocked;
            }
            SetInteractable(false);

        }
        
        protected override void Initialize()
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
            inspectInteraction = new Interaction
            {
                InteractionText = "Inspect",
                Interact = InspectDrawer
            };
            focusInteraction = new Interaction
            {
                InteractionText = "Focus",
                Interact = Focus
            };
            focusNextInteraction = new Interaction
            {
                InteractionText = "Focus to Next",
                Interact = FocusToNext
            };
            
            unfocusInteraction = new Interaction
            {
                InteractionText = "Stop Focusing",
                Interact = StopFocusing
            };
            
            closeInspectInteraction = new Interaction
            {
                InteractionText = "Stop Inspecting",
                Interact = StopInspecting
            };
            
            focusInteraction = new Interaction
            {
                InteractionText = "Focus",
                Interact = Focus
            };
            
            unfocusInteraction = new Interaction
            {
                InteractionText = "Stop Focusing",
                Interact = StopFocusing
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



        void OpenDrawer(int index)
        {
            index %= drawerPanels.Length; 
            if (isDrawerOpened)
            {
                currentPanel.Close();
            }
            openedDrawerIndex = index;
            currentPanel.Open();
        }
        
        void InspectDrawer()
        {
            currentPanel.Inspect();
        }

        void StopInspecting()
        {
            currentPanel.StopInspect();
        }

        private void Focus()
        {
            currentPanel.Focus();
            OnFocused();
        }

        private void FocusToNext()
        {
            currentPanel.FocusNext();
            OnFocused();
        }
        private void StopFocusing()
        {
            currentPanel.StopFocus();
            OnFocusEnded();
        }
        
        private void CloseDrawer()
        {
            drawerPanels[openedDrawerIndex].Close();
            openedDrawerIndex = -1;
        }

        void OnDrawerOpened()
        {
            Interactions = new List<Interaction> {openNextInteraction, focusInteraction, closeInteraction };
            SetInteractable(true);

        }
        
        void OnDrawerClosed()
        {
            Interactions = new List<Interaction> { openInteraction };
            SetInteractable(true);
        }

        void OnDrawerLocked()
        {
            Interactions = new List<Interaction> { unlockInteraction};
            SetInteractable(true);
        }
        
        void OnDrawerUnLocked()
        {
            Interactions = new List<Interaction> { openInteraction};
            SetInteractable(true);
        }
        private void OnFocused()
        {
            if (currentPanel.FocusedInspectable != null)
            {
                Interactions = new List<Interaction> { inspectInteraction, focusNextInteraction, unfocusInteraction };
            }
            else
            {
                Interactions = new List<Interaction> { unfocusInteraction };
            }
            SetInteractable(true);
        }

        private void OnFocusEnded()
        {
            OnDrawerOpened();
        }
        
        void OnInspected()
        {
            SetInspectedInteractions();
            currentPanel.FocusedInspectable.OnInteracted += OnInspectedInteracted;
            SetInteractable(true);

        }

        private void SetInspectedInteractions()
        {
            Interactions = new List<Interaction> { closeInspectInteraction };
            foreach (Interaction interaction in currentPanel.FocusedInspectable.Interactions)
            {
                Interactions.Add(interaction);
            }
        }

        void OnInspectedInteracted()
        {
            SetInspectedInteractions();
            SetInteractable(true);
        }
        
        void OnInspectEnded()
        {
            currentPanel.FocusedInspectable.OnInteracted -= OnInspectedInteracted;
            OnFocused();
        }
    }
}