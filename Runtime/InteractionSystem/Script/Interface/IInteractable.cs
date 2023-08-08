using System.Collections.Generic;
using CodeBase.Core;

namespace InteractionSystem
{
    public interface IInteractable : IHaveTransform
    {
        bool IsInteractable{ get; }
        List<Interaction> Interactions{ get; }
        void Interact(int index);
    }
}