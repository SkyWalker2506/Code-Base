using System;
using System.Collections.Generic;
using UnityEngine;

namespace TriggerSystem
{
    public abstract class OverlapTriggerBase<T> : IOverlapTrigger <T> where T : MonoBehaviour
    {
        public IOverlapTriggerData OverlapTriggerData { get; }
        protected Vector3 CenterPosition => OverlapTriggerData.Center + OverlapTriggerData.Offset;
        protected Quaternion CenterRotation => OverlapTriggerData.Rotation;
        protected float Size => OverlapTriggerData.Size;
        public HashSet<Collider> OverlappedObjects { get; private set; }
        public Action<T> OnTriggerEnter { get; set; }
        public Action<T> OnTriggerStay { get; set; }
        public Action<T> OnTriggerExit { get; set; }

        protected OverlapTriggerBase(IOverlapTriggerData overlapTriggerData)
        {
            OverlapTriggerData = overlapTriggerData;
            OverlappedObjects = new HashSet<Collider>(GetOverlapped());
        }
        
        public void Update()
        {
            HashSet<Collider> newOverlappedObjects = GetOverlapped();
            foreach (var newOverlappedObject in newOverlappedObjects)
            {
                if(OverlappedObjects.Contains(newOverlappedObject))
                {
                    if (OnTriggerStay != null && OnTriggerStay.GetInvocationList().Length > 0)
                    {
                        if (newOverlappedObject.TryGetComponent(out T component))
                        {   
                            OnTriggerStay.Invoke(component);
                        }
                    }
                }
                else
                {
                    if (OnTriggerEnter != null && OnTriggerEnter.GetInvocationList().Length > 0)
                    {
                        if (newOverlappedObject.TryGetComponent(out T component))
                        {   
                            OnTriggerEnter.Invoke(component);
                        }
                    }
                }
            }
            foreach (var overlappedObject in OverlappedObjects)
            {
                if(!newOverlappedObjects.Contains(overlappedObject))
                {
                    if (OnTriggerExit != null && OnTriggerExit.GetInvocationList().Length > 0)
                    {
                        if (overlappedObject.TryGetComponent(out T component))
                        {   
                            OnTriggerExit.Invoke(component);
                        }
                    }
                }
            }

            OverlappedObjects = newOverlappedObjects;
        }

        protected abstract HashSet<Collider> GetOverlapped();
        public virtual void DrawGizmo() { }

    }
}
