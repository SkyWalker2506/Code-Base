using UnityEngine;

namespace InteractionSystem
{
    public abstract class Interactor : IInteractor
    {
        public InteractionUI InteractionUI => InteractionUI.Instance;

        public void Interact(IInteractable interactable, int index)
        {
            if (interactable.IsInteractable)
            {
                interactable.Interact(index);
            }
            else
            {
                Debug.Log($"{interactable} is not interactable" );
            }
        }

        public abstract IInteractable GetInteractable();

    }
}