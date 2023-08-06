using System;
using UnityEngine;

namespace InteractionSystem
{
    public abstract class LockBase : MonoBehaviour, ILockable
    {
        public bool IsLocked { get; protected set; }
        public Action OnLocked { get; set; }
        public Action OnUnlocked { get; set; }
        
        public virtual void Lock()
        {
            IsLocked = true;
            OnLocked?.Invoke();
        }

        public virtual void Unlock()
        {
            IsLocked = false;
            OnUnlocked?.Invoke();
        }
    }
}