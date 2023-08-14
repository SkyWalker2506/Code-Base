using System;
using InteractionSystem;
using UnityEngine;

namespace DetectiveGame.Interactable
{
    public class Key : Interactable, ICollectable
    {
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public int ID { get; private set; }
        public Action OnCollected { get; set; }
        protected override void Initialize()
        {
            CollectableManager.AddCollectable(this);
            SetInteraction(new Interaction
            {
                InteractionText = $"Collect {Name}", 
                Interact = Collect
            });
        }

        public void Collect()
        {
            OnCollected?.Invoke();
            CollectableManager.Collect(this);
            gameObject.SetActive(false);
        }

    }
}