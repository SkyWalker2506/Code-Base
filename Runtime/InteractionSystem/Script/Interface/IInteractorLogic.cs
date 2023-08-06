using CodeBase.Core;
using UnityEngine;

namespace InteractionSystem
{
    public interface IInteractorLogic : IHaveTransform
    {
        IInteractor Interactor { get; }
        void Update();
        void Interact(int index);
    }
}