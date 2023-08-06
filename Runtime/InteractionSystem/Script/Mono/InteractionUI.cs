using UnityEngine;

namespace InteractionSystem
{
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField] private GameObject UIParent;
        [SerializeField] private string defaultInteractionText = "Interact";
        [SerializeField] private InteractionPanel[] interactionPanels;
        public static InteractionUI Instance;
        
        private void Awake()
        {
            Instance = this;
            HideInteractionUI();
        }

        public void ShowInteractionUI(IInteractable interactable)
        {
            UIParent.SetActive(true);
            DisableInteractionPanels();
            for (int i = 0; i < interactable.Interactions.Length; i++)
            {
                interactionPanels[i].SetText(interactable.Interactions[i].InteractionText == ""?
                defaultInteractionText:interactable.Interactions[i].InteractionText);
                interactionPanels[i].gameObject.SetActive(true);
            }
        }

        public void HideInteractionUI()
        {
            UIParent.SetActive(false);
        }

        void DisableInteractionPanels()
        {
            foreach (InteractionPanel panel in interactionPanels)
            {
                panel.gameObject.SetActive(false);
            }
        }

    }
}