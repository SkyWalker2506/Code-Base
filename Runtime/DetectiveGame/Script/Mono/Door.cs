using DetectiveGame.FiniteStateSystem;
using DetectiveGame.Interactable.Parts;
using UnityEngine;

namespace DetectiveGame.Interactable
{
    public class Door : Interactable
    {
        [field:SerializeField] public DoorPanel DoorPanel { get; private set; }
        [field:SerializeField] public LockBase DoorLock{ get; private set; }

        [field:SerializeField] public bool IsLockable{ get; private set; } 
        [field:SerializeField] public bool InitialLocked{ get; private set; } 
        [field:SerializeField] public bool InitialDoorOpen{ get; private set; }
        private DoorStateController doorStateController{ get;  set; }

        protected override void Initialize()
        {
            doorStateController = new DoorStateController(this);
        }

        private void OnEnable()
        {
            SetInteractable(true);
        }

        private void OnDisable()
        {
            SetInteractable(false);
        }
    }
}