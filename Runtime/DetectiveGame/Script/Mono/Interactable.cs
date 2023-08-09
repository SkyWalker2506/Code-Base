using System;
using System.Collections.Generic;
using InteractionSystem;
using UnityEngine;

namespace DetectiveGame.Interactable
{
    public abstract class Interactable : MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; private set; }
        public List<Interaction> Interactions { get; protected set; }
    
        public Action OnInteracted { get; set; }

        private void Awake()
        {
            Initialize();
        }

        protected abstract void Initialize();

        public void Interact(int index)
        {
            IsInteractable = false;
            Interactions[index].Interact();
        }
        
        public void SetInteractable(bool isInteractable)
        {
            IsInteractable = isInteractable;
        }

        public void SetInteractions(List<Interaction> interactions)
        {
            Interactions = interactions;
        }

    }
}