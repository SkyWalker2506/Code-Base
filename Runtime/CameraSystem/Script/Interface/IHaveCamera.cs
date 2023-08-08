using Cinemachine;

namespace CameraSystem
{
    public interface IHaveCamera
    {
        CinemachineVirtualCamera Camera { get; }
        void ActivateCamera();
    }
}