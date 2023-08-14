using System;
using AudioSystem;
using InteractionSystem;
using UnityEngine;

namespace DetectiveGame.Interactable
{
    public abstract class LockBase : MonoBehaviour, ILockable, IAudible
    {
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
        public AudioClip AudioClip { get; protected set; }

        [SerializeField] private AudioClip lockClip; 
        [SerializeField] private AudioClip unlockClip;
        public bool IsLocked { get; protected set; }
        public Action OnLocked { get; set; }
        public Action OnUnlocked { get; set; }
        public Action OnUnlockFailed { get; set; }

        public void SetLocked()
        {
            IsLocked = true;
        }
        
        public void SetUnlocked()
        {
            IsLocked = false;
        }
        
        public virtual void Lock()
        {
            PlayAudio(lockClip);
            IsLocked = true;
            OnLocked?.Invoke();
        }

        public virtual void Unlock()
        {
            PlayAudio(unlockClip);
            IsLocked = false;
            OnUnlocked?.Invoke();
        }

        protected void PlayAudio(AudioClip audioClip)
        {
            AudioClip = audioClip;
            PlayAudio();
        }
        
        public void PlayAudio()
        {
            AudioSource.PlayOneShot(AudioClip);
        }
    }
}