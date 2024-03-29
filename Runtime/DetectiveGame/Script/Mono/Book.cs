﻿using System.Collections.Generic;
using InteractionSystem;
using UnityEngine;

namespace DetectiveGame.Interactable
{
    public class Book : InteractableBase
    {
        [SerializeField] private string bookName;
        private Interaction readInteraction;
        private Interaction closeInteraction;

        protected override void Initialize()
        {
            readInteraction = new Interaction
            {
                InteractionText = $"Read {bookName}",
                Interact = Read
            };
            closeInteraction = new Interaction
            {
                InteractionText = "Close",
                Interact = Close
            };
            Interactions = new List<Interaction> { readInteraction };
        }

        void Read()
        {
            OnRead();
        }

        void Close()
        {
            OnClosed();
        }
        
        void OnRead()
        {
            Interactions = new List<Interaction> { closeInteraction };
            SetInteractable(true);

            OnInteracted?.Invoke();
        }
        
        void OnClosed()
        {
            Interactions = new List<Interaction> { readInteraction };
            SetInteractable(true);

            OnInteracted?.Invoke();
        }

    }
}