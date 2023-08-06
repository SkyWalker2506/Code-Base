namespace InteractionSystem
{
    public interface IInteractor
    {
        public InteractionUI InteractionUI { get;  }
        public void Interact(IInteractable interactable);
        public IInteractable GetInteractable();
    }

}