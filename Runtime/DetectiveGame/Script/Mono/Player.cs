using DetectiveGame.InteractionSystem;
using InteractionSystem;
using UnityEngine;
using UnityEngine.InputSystem;


namespace DetectiveGame.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInputAsset playerInput;
        [SerializeField] private InteractorData interactorData;

        private IInteractorLogic interactorLogic;

        private void Awake()
        {
            interactorLogic = new GameInteractorLogic(transform, interactorData);
            playerInput = new PlayerInputAsset();
        }

        private void OnEnable()
        {
            playerInput.Enable();
            playerInput.Player.Interact1.performed += TryInteract1;
            playerInput.Player.Interact2.performed += TryInteract2;
            playerInput.Player.Interact3.performed += TryInteract3;
            playerInput.Player.Interact4.performed += TryInteract4;
        }

        private void OnDisable()
        {
            playerInput.Disable();
            playerInput.Player.Interact1.performed -= TryInteract1;
            playerInput.Player.Interact2.performed -= TryInteract2;
            playerInput.Player.Interact3.performed -= TryInteract3;
            playerInput.Player.Interact4.performed -= TryInteract4;
        }

        private void Update()
        {
            interactorLogic.Update();
        }
        
        private void TryInteract1(InputAction.CallbackContext callbackContext) { interactorLogic.Interact(0);}
        private void TryInteract2(InputAction.CallbackContext callbackContext) { interactorLogic.Interact(1);}
        private void TryInteract3(InputAction.CallbackContext callbackContext) { interactorLogic.Interact(2);}
        private void TryInteract4(InputAction.CallbackContext callbackContext) { interactorLogic.Interact(3);}
        
    }
}
