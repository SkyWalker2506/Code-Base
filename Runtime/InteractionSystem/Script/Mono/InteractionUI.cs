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
            HideInteractionUI();
        }

        public void ShowInteractionUI(IInteractable interactable)
        {
            UIParent.SetActive(true);
            interactionTextObject.SetText(interactable.Interactions[0].InteractionUIData.InteractionText == ""?
                defaultInteractionText:interactable.Interactions[0].InteractionUIData.InteractionText);
            interactionImageObject.sprite = interactable.Interactions[0].InteractionUIData.InteractionSprite == null
                ? defaultInteractionSprite
                : interactable.Interactions[0].InteractionUIData.InteractionSprite;
        }

        public void HideInteractionUI()
        {
            UIParent.SetActive(false);
        }
    }
}