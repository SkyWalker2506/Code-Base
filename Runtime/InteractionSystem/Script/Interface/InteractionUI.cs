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
            if (interactable.InteractionText == "")
            {
                interactionTextObject.SetText(interactable.InteractionText);
            }
            else
            {
                interactionTextObject.SetText(defaultInteractionText);
            }
        }
    }
}