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
        public List<IInteractable> Inspectables { get; private set; } = new List<IInteractable>();
        public IInteractable InspectedObject => Inspectables.Count > 0 ? Inspectables[currentInspectedIndex] : null;

        private int currentInspectedIndex; 
        [field: SerializeField] public CinemachineVirtualCamera Camera { get; private set; }
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
        [SerializeField] private AudioClip openClip; 
        [SerializeField] private AudioClip closeClip;
        public AudioClip AudioClip { get; private set; }

        public Action OnInspect { get; set; }
        public Action OnInspectEnded { get; set; }
        
        private void Awake()
        {
            Inspectables = new List<IInteractable>();
            foreach (GameObject inspectInteractable in inspectInteractables)
            {
                if (inspectInteractable.TryGetComponent(out IInteractable interactable))
                {
                    Inspectables.Add(interactable);
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
            currentInspectedIndex = 0;
            ActivateCamera();
            if (InspectedObject!=null)
            {
                Camera.LookAt = InspectedObject.transform;
            }
        }
        

        public void InspectPrev()
        {
            currentInspectedIndex = (currentInspectedIndex - 1 + Inspectables.Count) % Inspectables.Count;
        }

        public void InspectNext()
        {
            currentInspectedIndex = (currentInspectedIndex + 1) % Inspectables.Count;
        }
        
        public void Inspect()
        {
            ActivateCamera();
            Camera.LookAt = InspectedObject.transform;
            Invoke(nameof(OnInspected), .25f);
        }

        void OnInspected()
        {
            OnInspect?.Invoke();
        }

        public void StopInspect()
        {
            CameraManager.ActivatePlayerCamera();
            Invoke(nameof(OnStopInspect), .25f);
        }

        void OnStopInspect()
        {
            OnInspectEnded?.Invoke();
        }

        public void SetInspectableIndex(int index)
        {
            currentInspectedIndex = index;
        }
    }
}