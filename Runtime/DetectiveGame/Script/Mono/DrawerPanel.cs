using System;
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
        [SerializeField] private GameObject[] inspectInteractables;
        public List<IInteractable> InspectInteractables { get; private set; } = new List<IInteractable>();
        public IInteractable FocusedInspectable => InspectInteractables.Count > 0 ? InspectInteractables[currentFocusIndex] : null;

        private int currentFocusIndex; 
        [field: SerializeField] public CinemachineVirtualCamera Camera { get; private set; }
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
        [SerializeField] private AudioClip openClip; 
        [SerializeField] private AudioClip closeClip;
        public AudioClip AudioClip { get; private set; }

        public Action OnInspect { get; set; }
        public Action OnInspectEnded { get; set; }
        
        private void Awake()
        {
            InspectInteractables = new List<IInteractable>();
            foreach (GameObject inspectInteractable in inspectInteractables)
            {
                if (inspectInteractable.TryGetComponent(out IInteractable interactable))
                {
                    InspectInteractables.Add(interactable);
                    interactable.transform.gameObject.layer = 0;
                }
            }
        }

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

        public void Focus()
        {
            currentFocusIndex = 0;
            ActivateCamera();
            if (FocusedInspectable!=null)
            {
                Camera.LookAt = FocusedInspectable.transform;
            }
        }
        
        public void FocusNext()
        {
            currentFocusIndex = (currentFocusIndex + 1) % InspectInteractables.Count;
            Camera.LookAt = FocusedInspectable.transform;
        }
        
        public void StopFocus()
        {
            CameraManager.ActivatePlayerCamera();
        }

        public void Inspect()
        {
            Invoke(nameof(OnInspected), 1);
        }

        void OnInspected()
        {
            OnInspect?.Invoke();
        }

        public void StopInspect()
        {
            Invoke(nameof(OnStopInspect), 1);
        }

        void OnStopInspect()
        {
            OnInspectEnded?.Invoke();
        }
    }
}