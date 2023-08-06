namespace InteractionSystem
{
    public interface IInteractor
    {
        public InteractionUI InteractionUI { get;  }
        public void Interact(IInteractable interactable, int index);
        public IInteractable GetInteractable();
    }

}