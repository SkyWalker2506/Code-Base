using System;

namespace InteractionSystem
{
    public interface ILockable 
    {
        bool IsLocked{get;}
        Action OnLocked{get; set;}
        Action OnUnlocked{get; set;}
        void Lock();
        void Unlock();
        
    }
}