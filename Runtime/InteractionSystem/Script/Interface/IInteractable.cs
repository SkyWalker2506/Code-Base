using System;
using System.Collections.Generic;
using CodeBase.Core;

namespace InteractionSystem
{
    public interface IInteractable : IHaveTransform
    {
        bool IsInteractable{ get; }
        List<Interaction> Interactions { get; }
        void Interact(int index);
        Action OnInteracted{ get; set; }
        void SetInteractable(bool isInteractable);
        void SetInteraction(Interaction interaction);
        void SetInteractions(List<Interaction> interactions);
        void AddInteraction(Interaction interaction);
        void RemoveInteraction(Interaction interaction);
    }
}