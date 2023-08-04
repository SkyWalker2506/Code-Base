using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InteractionSystem
{
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField] private GameObject UIParent;
        [SerializeField] private TMP_Text interactionTextObject;
        [SerializeField] private Image interactionImageObject;
        [SerializeField] private string defaultInteractionText = "Interact";
        [SerializeField] private Sprite defaultInteractionSprite;
        
        public static InteractionUI Instance;
        
        private void Awake()
        {
            Instance = this;
        }

        public void ShowInteractionUI(IInteractable interactable)
        {
            UIParent.SetActive(true);
            interactionTextObject.SetText(interactable.InteractionText == ""?defaultInteractionText:interactable.InteractionText);
            interactionImageObject.sprite = interactable.InteractionSprite == null
                ? defaultInteractionSprite
                : interactable.InteractionSprite;
        }

        public void HideInteractionUI()
        {
            UIParent.SetActive(false);
        }
    }
}