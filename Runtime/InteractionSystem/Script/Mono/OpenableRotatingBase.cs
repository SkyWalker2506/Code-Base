using System;
using DG.Tweening;
using UnityEngine;

namespace InteractionSystem
{
    public abstract class OpenableMovingBase : MonoBehaviour, IOpenableMoving
    {
        [field : SerializeField] public Vector3 OpenedPosition { get; private set;}
        [field : SerializeField] public Vector3 ClosedPosition { get; private set;}

        [field : SerializeField] public float OpeningDuration { get; set; }
        public bool IsOpened { get; private set; }
        public Action OnOpened { get; set; }
        public Action OnClosed { get; set; }
        
        private void Start()
        {
            transform.localPosition = IsOpened? OpenedPosition:ClosedPosition;
        }

        
        public virtual void Open()
        {
            transform.DOLocalMove(OpenedPosition, OpeningDuration).OnComplete(() =>
            {
                IsOpened = true;
                OnOpened?.Invoke();
            });
        }

        public virtual void Close()
        {
            transform.DOLocalMove(ClosedPosition, OpeningDuration).OnComplete(() =>
            {
                IsOpened = false;
                OnClosed?.Invoke();
            });
        }

    }
    public abstract class OpenableRotatingBase : MonoBehaviour, IOpenableRotating
    {
        [field : SerializeField] public Vector3 OpenedRotation { get; private set; }
        [field : SerializeField] public Vector3 ClosedRotation { get; private set;}

        [field : SerializeField] public float OpeningDuration { get; set; }
        public bool IsOpened { get; protected set; }
        public Action OnOpened { get; set; }
        public Action OnClosed { get; set; }

        private void Start()
        {
            transform.localRotation = IsOpened? Quaternion.Euler(OpenedRotation):Quaternion.Euler(ClosedRotation);
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