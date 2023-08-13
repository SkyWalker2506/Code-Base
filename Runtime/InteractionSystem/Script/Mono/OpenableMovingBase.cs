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

        public void Initialize(bool isOpened)
        {
            IsOpened = isOpened;
        }
        
        public void SetOpened()
        {
            transform.localPosition = OpenedPosition;
            IsOpened = true;
        }

        public void SetClosed()
        {
            transform.localPosition = ClosedPosition;
            IsOpened = false;
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
}