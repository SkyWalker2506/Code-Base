using DetectiveGame.InteractionSystem;
using InteractionSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DetectiveGame.PlayerSystem
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour movementController;
        [SerializeField] private InteractorData interactorData;
        private IInteractorLogic interactorLogic;
        private PlayerInputAsset playerInput;
        private static Player instance;  
        
        private void Awake()
        {
            instance = this;
            interactorLogic = new GameInteractorLogic(transform, interactorData);
            playerInput = new PlayerInputAsset();
        }

        private void OnEnable()
        {
            playerInput.Enable();
            playerInput.OnInteract.Interact1.performed += TryInteract1;
            playerInput.OnInteract.Interact2.performed += TryInteract2;
            playerInput.OnInteract.Interact3.performed += TryInteract3;
            playerInput.OnInteract.Interact4.performed += TryInteract4;
            playerInput.OnInteract.ArrowInteract.performed += ArrowInteract;
        }

        private void OnDisable()
        {
            playerInput.Disable();
            playerInput.OnInteract.Interact1.performed -= TryInteract1;
            playerInput.OnInteract.Interact2.performed -= TryInteract2;
            playerInput.OnInteract.Interact3.performed -= TryInteract3;
            playerInput.OnInteract.Interact4.performed -= TryInteract4;
            playerInput.OnInteract.ArrowInteract.performed -= ArrowInteract;
        }

        private void Update()
        {
            interactorLogic.Update();
        }
        
        private void TryInteract1(InputAction.CallbackContext callbackContext) { interactorLogic.Interact(0);}
        private void TryInteract2(InputAction.CallbackContext callbackContext) { interactorLogic.Interact(1);}
        private void TryInteract3(InputAction.CallbackContext callbackContext) { interactorLogic.Interact(2);}
        private void TryInteract4(InputAction.CallbackContext callbackContext) { interactorLogic.Interact(3);}

        private void ArrowInteract(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.ReadValue<Vector2>().x > .9f)
            {
                Input.OnRight?.Invoke();
            }
            else if (callbackContext.ReadValue<Vector2>().x < -.9f)
            {
                Input.OnLeft?.Invoke();
            }
        }

        public static void ToggleMovementController(bool isActive)
        {
            instance.movementController.enabled = isActive;
        }
    }
}
