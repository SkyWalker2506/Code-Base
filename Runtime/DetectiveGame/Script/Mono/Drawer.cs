using DetectiveGame.FiniteStateSystem;
using DetectiveGame.Interactable.Parts;
using UnityEngine;

namespace DetectiveGame.Interactable
{
    public class Drawer : Interactable
    {
        [field:SerializeField] public LockBase DrawerLock{ get; private set; }
        [SerializeField] private DrawerPanel[] drawerPanels;
        public DrawerPanel CurrentPanel => currentDrawerIndex>=0?drawerPanels[currentDrawerIndex]:null;
        public DrawerPanel NextPanel => drawerPanels[(currentDrawerIndex+1)%drawerPanels.Length];
        [field:SerializeField] public bool IsLockable{ get; private set; }
        [field:SerializeField] public bool InitialLocked{ get; private set; } 
        [Tooltip("-1 means all drawers are closed")]
        [field:SerializeField] public int OpenInitialDrawerIndex = -1; 
        public int CurrentDrawerIndex
        {
            get => currentDrawerIndex;
            set => currentDrawerIndex = value%drawerPanels.Length;
        } 
        private int currentDrawerIndex = -1; 

        private DrawerStateController drawerStateController{ get;  set; }

        protected override void Awake()
        {
            base.Awake();
            CurrentDrawerIndex = OpenInitialDrawerIndex;
        }

        protected override void Initialize()
        {
            drawerStateController = new DrawerStateController(this);
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