using UnityEngine;
using Input = DetectiveGame.PlayerSystem.Input;

namespace InteractionSystem
{
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField] private GameObject UIParent;
        [SerializeField] private string defaultInteractionText = "Interact";
        [SerializeField] private InteractionPanel[] interactionPanels;
        [SerializeField] private GameObject leftPanel;
        [SerializeField] private GameObject rightPanel;
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
            for (int i = 0; i < interactable.Interactions.Count; i++)
            {
                interactionPanels[i].SetText(interactable.Interactions[i].InteractionText == ""?
                defaultInteractionText:interactable.Interactions[i].InteractionText);
                interactionPanels[i].gameObject.SetActive(true);
            }
            leftPanel.SetActive(Input.OnLeft != null);
            rightPanel.SetActive(Input.OnRight != null);
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