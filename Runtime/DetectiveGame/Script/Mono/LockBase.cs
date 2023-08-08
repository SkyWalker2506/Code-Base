using System;
using AudioSystem;
using InteractionSystem;
using UnityEngine;

namespace DetectiveGame.Interactable
{
    public abstract class LockBase : MonoBehaviour, ILockable, IAudible
    {
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
        public AudioClip AudioClip { get; private set; }

        [SerializeField] private AudioClip lockClip; 
        [SerializeField] private AudioClip unlockClip;
        public bool IsLocked { get; protected set; }
        public Action OnLocked { get; set; }
        public Action OnUnlocked { get; set; }
        
        public virtual void Lock()
        {
            AudioClip = lockClip;
            PlayAudio();
            IsLocked = true;
            OnLocked?.Invoke();
        }

        public virtual void Unlock()
        {
            AudioClip = unlockClip;
            PlayAudio();
            IsLocked = false;
            OnUnlocked?.Invoke();
        }

        public void PlayAudio()
        {
            AudioSource.PlayOneShot(AudioClip);
        }
    }
}