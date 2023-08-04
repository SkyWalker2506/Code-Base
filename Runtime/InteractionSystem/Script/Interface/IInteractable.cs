using System;
using CodeBase.Core;

namespace InteractionSystem
{
    public interface IInteractable : IHaveTransform
    {
        bool IsInteractable{ get; }
        string InteractionText { get; }
        Action OnInteractionStarted{ get; set; }
        Action OnInteractionEnded{ get; set; }
        void Interact();
    }
}