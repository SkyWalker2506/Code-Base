using TMPro;
using UnityEngine;

namespace InteractionSystem
{
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField] private GameObject UIParent;
        [SerializeField] private TMP_Text interactionTextObject;
        [SerializeField] private string defaultInteractionText = "Interact";
        
        public static InteractionUI Instance;
        
        private void Awake()
        {
            Instance = this;
        }

        public void ShowInteractionUI(IInteractable interactable)
        {
            UIParent.SetActive(true);
            if (interactable.InteractionText == "")
            {
                interactionTextObject.SetText(interactable.InteractionText);
            }
            else
            {
                interactionTextObject.SetText(defaultInteractionText);
            }
        }

        public void HideInteractionUI()
        {
            UIParent.SetActive(false);
        }
    }

    public interface IInteractor
    {
        public InteractionUI InteractionUI { get;  }
        public void Interact(IInteractable interactable);
        public IInteractable GetInteractable();
    }

    public abstract class Interactor : IInteractor
    {
        public InteractionUI InteractionUI
        {
            get { return InteractionUI.Instance; }
        } 

        public void Interact(IInteractable interactable)
        {
            interactable.Interact();
        }

        public abstract IInteractable GetInteractable();

    }
    
    
}