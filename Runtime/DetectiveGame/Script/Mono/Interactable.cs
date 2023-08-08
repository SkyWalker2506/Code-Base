using System.Collections.Generic;
using InteractionSystem;
using UnityEngine;

namespace DetectiveGame.Interactable
{
    public abstract class Interactable : MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; protected set; }
        public List<Interaction> Interactions { get; protected set; }
    
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
    }
}