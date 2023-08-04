using System;
using CodeBase.Core;
using UnityEngine;

namespace InteractionSystem
{
    public interface IInteractable : IHaveTransform
    {
        bool IsInteractable{ get; }
        string InteractionText { get; }
        Sprite InteractionSprite { get; }
        Action OnInteractionStarted{ get; set; }
        Action OnInteractionEnded{ get; set; }
        void Interact();
    }
}