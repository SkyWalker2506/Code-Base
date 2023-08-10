﻿using DetectiveGame.Interactable;
using InteractionSystem;

namespace DetectiveGame.FiniteStateSystem
{
    public abstract class DrawerState : InteractableState
    {
        protected DrawerStateController DISC => (DrawerStateController)ISC;
        protected readonly Drawer drawer;

        protected DrawerState(DrawerStateController  interactableStateController) : base(interactableStateController)
        {
            drawer = interactableStateController.Drawer;
        }
        /*
        private Interaction openInteraction;
        private Interaction openNextInteraction;
        private Interaction closeInteraction;
        private Interaction unlockInteraction;
        private Interaction inspectInteraction;
        private Interaction focusNextInteraction;
        private Interaction closeInspectInteraction;
        private Interaction focusInteraction;
        private Interaction unfocusInteraction;
        */
    }
}