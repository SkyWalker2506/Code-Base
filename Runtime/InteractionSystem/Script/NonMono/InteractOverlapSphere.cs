using System;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public class InteractOverlapSphere : Interactor
    {
        private Transform center{ get; }
        private float radius { get; }
        private float maxAngle { get; }
        LayerMask interactableLayer{ get; }

        public InteractOverlapSphere(Transform center, float radius, float maxAngle,LayerMask interactableLayer)
        {
            this.center = center;
            this.radius = radius;
            this.maxAngle = maxAngle;
            this.interactableLayer = interactableLayer;
        }
        
        public override IInteractable GetInteractable()
        {
            IInteractable selectedInteractable = null;
            Collider[] overlapedColliders = Physics.OverlapSphere(center.position, radius,interactableLayer);
            List<IInteractable> availableInteractables = new List<IInteractable>();
            foreach (Collider collider in overlapedColliders)
            {
                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    if (interactable.IsInteractable)
                    {
                        float dot =Vector3.Dot(center.forward,(interactable.transform.position-center.position).normalized);
                        Debug.Log(dot);
                        if (dot > 1 - maxAngle / 180)
                        {
                            availableInteractables.Add(interactable);
                        }
                    }
                }
            }

            float currentDistance = 1000;
            foreach (IInteractable interactable in availableInteractables)
            {
                float distance = Vector3.Distance(interactable.transform.position, center.position);
                if (currentDistance > distance)
                {
                    currentDistance = distance;
                    selectedInteractable = interactable;
                }
            }
            return selectedInteractable;
        }
    }
}