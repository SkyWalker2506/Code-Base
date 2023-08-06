using CodeBase.Core;
using FiniteState;

namespace InteractionSystem
{
    public interface IInteractable : IHaveTransform
    {
        bool IsInteractable{ get; }
        Interaction[] Interactions{ get; }
        void Interact(int index);
    }


}