using System;
using AudioSystem;
using InteractionSystem;
using UnityEngine;

namespace DetectiveGame.Interactable
{
    public class Key : InteractableBase, ICollectable, IAudible
    {
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public int ID { get; private set; }

        [field:SerializeField] public AudioSource AudioSource { get;  private set;}
        [field:SerializeField] public AudioClip AudioClip { get;  private set;}

        [SerializeField] private GameObject keyRenderer;
        
        public Action OnCollected { get; set; }
        protected override void Initialize()
        {
            CollectableManager.AddCollectable(this);
            SetInteraction(new Interaction
            {
                InteractionText = $"Collect {Name}", 
                Interact = Collect
            });
            SetInteractable(true);
        }

        public void Collect()
        {
            PlayAudio();
            OnCollected?.Invoke();
            CollectableManager.Collect(this);
            keyRenderer.SetActive(false);
            SetInteractable(false);
        }

        
        public void PlayAudio()
        {
            AudioSource.PlayOneShot(AudioClip);
        }
    }
}