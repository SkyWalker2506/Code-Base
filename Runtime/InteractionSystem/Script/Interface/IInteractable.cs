using System;
using CodeBase.Core;

namespace InteractionSystem
{
    public interface IInteractable : IHaveTranform
    {
        bool IsInteractable{ get; }
        string InteractionText { get; }
        void Interact();
        Action OnInteractionStarted{ get; set; }
        Action OnInteractionEnded{ get; set; }
    }
}