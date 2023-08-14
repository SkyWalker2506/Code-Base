using System;
using InteractionSystem;
using UnityEngine;

namespace DetectiveGame.Interactable
{
    public class Key : Interactable, ICollectable
    {
        [field:SerializeField] public string Name { get; private set; }
        public Action OnCollected { get; set; }
        protected override void Initialize()
        {
        }

        public void Collect()
        {
            OnCollected?.Invoke();
        }
    }
}