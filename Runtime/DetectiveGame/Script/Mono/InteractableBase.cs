﻿using System;
using System.Collections.Generic;
using InteractionSystem;
using UnityEngine;

namespace DetectiveGame.Interactable
{
    public abstract class InteractableBase : MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; private set; }
        public List<Interaction> Interactions { get; protected set; }
    
        public Action OnInteracted { get; set; }

        protected virtual void Awake()
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
        
        public void SetInteraction(Interaction interaction)
        {
            Interactions = new() { interaction };
        }

        public void SetInteractions(List<Interaction> interactions)
        {
            Interactions = interactions;
        }

        public void AddInteraction(Interaction interaction)
        {
            Interactions.Add(interaction);
        }

        public void AddInteractions(List<Interaction> interactions)
        {
            Interactions.AddRange(interactions);
        }

        public void RemoveInteraction(Interaction interaction)
        {
            if (Interactions.Contains(interaction))
            {
                Interactions.Remove(interaction);
            }
        }
    }
}