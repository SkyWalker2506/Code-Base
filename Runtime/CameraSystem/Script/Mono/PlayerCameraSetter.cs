using Cinemachine;
using UnityEngine;

namespace CameraSystem
{
    public class PlayerCameraSetter : MonoBehaviour
    {
        [SerializeField] private bool activatePlayerCamera = true;
        private CinemachineVirtualCamera playerCamera { get; set; }
        
        private void Awake()
        {
            playerCamera = GetComponent<CinemachineVirtualCamera>();
            if (playerCamera)
            {
                CameraManager.SetPlayerCamera(playerCamera);
                if (activatePlayerCamera)
                {
                    CameraManager.ActivatePlayerCamera();
                }
            }
        }
    }
}