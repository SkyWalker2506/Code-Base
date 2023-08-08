using System.Collections.Generic;
using AudioSystem;
using CameraSystem;
using Cinemachine;
using InteractionSystem;
using UnityEngine;

namespace DetectiveGame.Interactable.Parts
{
    public class DrawerPanel : OpenableMovingBase, IInspectable, IAudible, IHaveCamera
    {
        [field: SerializeField]public List<IInteractable> InspectInteractables { get; private set; }

        [field: SerializeField] public CinemachineVirtualCamera Camera { get; private set; }
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
        public AudioClip AudioClip { get; private set; }
        [SerializeField] private AudioClip openClip; 
        [SerializeField] private AudioClip closeClip;

        public override void Open()
        {
            AudioClip = openClip;
            PlayAudio();
            base.Open();
        }

        public override void Close()
        {
            AudioClip = closeClip;
            PlayAudio();
            base.Close();
        }

        public void PlayAudio()
        {
            AudioSource.PlayOneShot(AudioClip);
        }

        public void ActivateCamera()
        {
            CameraManager.ActivateCamera(Camera);
        }

        public void Inspect()
        {
            ActivateCamera();
        }
    }
}