using Cinemachine;

namespace CameraSystem
{
    public static class CameraManager
    {
        private static CinemachineVirtualCamera playerCamera { get; set; }
        private static CinemachineVirtualCamera currentCamera { get; set; }

        public static void SetPlayerCamera(CinemachineVirtualCamera camera)
        {
            playerCamera = camera;
        }

        public static void ActivatePlayerCamera()
        {
            ActivateCamera(playerCamera);
        }        
        
        public static void ActivateCamera(CinemachineVirtualCamera camera)
        {
            if (currentCamera)
            {
                currentCamera.enabled = false;
            }
            currentCamera = camera;
            camera.enabled = true;
        }
    }
}