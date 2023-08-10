using System;
using DG.Tweening;
using UnityEngine;

namespace InteractionSystem
{
    public abstract class OpenableRotatingBase : MonoBehaviour, IOpenableRotating
    {
        [field : SerializeField] public Vector3 OpenedRotation { get; private set; }
        [field : SerializeField] public Vector3 ClosedRotation { get; private set;}

        [field : SerializeField] public float OpeningDuration { get; set; }
        public bool IsOpened { get; protected set; }
        public Action OnOpened { get; set; }
        public Action OnClosed { get; set; }

        public void SetOpened()
        {
            transform.localRotation = Quaternion.Euler(OpenedRotation);
            IsOpened = true;
        }
        
        public void SetClosed()
        {
            transform.localRotation = Quaternion.Euler(ClosedRotation);
            IsOpened = false;
        }

        public virtual void Open()
        {
            transform.DOLocalRotate(OpenedRotation, OpeningDuration).OnComplete(() =>
            {
                IsOpened = true;
                OnOpened?.Invoke();
            });
        }
        
        public virtual void Close()
        {
            transform.DOLocalRotate(ClosedRotation, OpeningDuration).OnComplete(() =>
            {
                IsOpened = false;
                OnClosed?.Invoke();
            });
        }
        
        public void Switch()
        {
            if (IsOpened)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }
}