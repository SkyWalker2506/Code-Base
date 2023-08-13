using InteractionSystem;
using UnityEngine;

namespace DetectiveGame.InteractionSystem
{
    public class GameInteractorLogic : IInteractorLogic
    {
        public Transform transform { get; }
        public IInteractor Interactor { get; }
        private float checkInterval;
        private float lastCheckedTime {get; set; }
        private IInteractable currentInteractable {get; set; }
        public GameInteractorLogic(Transform player, InteractorData data)
        {
            Interactor = new InteractOverlapSphere(player, data.CheckRadius, data.CheckAngle, data.InteractableLayerMask);
            checkInterval = data.CheckIntervalMS*.001f;
            transform = player;
        }
            
        public void Update()
        {
            if (lastCheckedTime + checkInterval < Time.time)
            {
                SetCurrentInteractable();
                SetInteractionUI();
                lastCheckedTime = Time.time;
            }
        }

        public void Interact(int index)
        {
            if (currentInteractable != null)
            {
                Interactor.Interact(currentInteractable, index);
                currentInteractable = null;
                Interactor.InteractionUI.HideInteractionUI();
            }
        }

        private void SetCurrentInteractable()
        {
            currentInteractable = Interactor.GetInteractable();
        }
        
        private void SetInteractionUI()
        {
            if (currentInteractable == null)
            {
                Interactor.InteractionUI.HideInteractionUI();
            }
            else
            {
                Interactor.InteractionUI.ShowInteractionUI(currentInteractable);
            }   
        }
    }
}