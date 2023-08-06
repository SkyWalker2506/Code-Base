using System;
using System.Numerics;

namespace InteractionSystem
{
    public interface IInteraction
    {
        InteractionUIData InteractionUIData{ get; set; }
        Action OnInteractionStarted{ get; set; }
        Action OnInteractionEnded{ get; set; }
        void Interact();
    }

    public class RotateInteraction : IInteraction
    {
        private Vector3 TargetRotation;
        public InteractionUIData InteractionUIData { get; set; }
        public Action OnInteractionStarted { get; set; }
        public Action OnInteractionEnded { get; set; }
        
        public void Interact()
        {
            
        }
    }
}