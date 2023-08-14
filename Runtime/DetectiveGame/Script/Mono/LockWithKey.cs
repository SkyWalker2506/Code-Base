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
                 int failWaitTime = 2;
                 InteractionUI.Instance.ShowMessage($"{CollectableManager.Collectables[ID].Name} is Required",failWaitTime);
                 Invoke(nameof(CallOnUnlockFailed),failWaitTime );
             }
         }

         private void CallOnUnlockFailed()
         {
             OnUnlockFailed?.Invoke();
         }
    }
}