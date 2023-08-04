using UnityEngine;

namespace InteractionSystem
{
    public abstract class Interactor : IInteractor
    {
        public InteractionUI InteractionUI => InteractionUI.Instance;

        public void Interact(IInteractable interactable)
        {
            if (interactable.IsInteractable)
            {
                interactable.Interact();
            }
            else
            {
                Debug.Log($"{interactable} is not interactable" );
            }
        }

        public abstract IInteractable GetInteractable();

    }
}