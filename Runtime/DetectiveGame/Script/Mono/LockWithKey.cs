using InteractionSystem;
using UnityEngine;

namespace DetectiveGame.Interactable
{
    public class LockWithKey : LockBase, IRequireCollectable
    {
         [field:SerializeField] public int ID { get; private set; }
         public bool IsCollected => CollectableManager.IsCollected(ID);
         [SerializeField] private AudioClip failedUnlockClip;


         public override void Unlock()
         {
             if (IsCollected)
             {
                base.Unlock();
             }
             else
             {
                 PlayAudio(failedUnlockClip);
                 InteractionUI.Instance.ShowMessage("Key is Required",1);
                 Invoke(nameof(CallOnUnlockFailed),1);
             }
         }

         private void CallOnUnlockFailed()
         {
             OnUnlockFailed?.Invoke();
         }
    }
}