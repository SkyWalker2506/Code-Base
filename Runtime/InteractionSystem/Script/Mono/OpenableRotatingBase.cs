using System;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;

namespace InteractionSystem
{
    public abstract class OpenableRotatingBase : MonoBehaviour, IOpenableRotating
    {
        [field : SerializeField] public Vector3 OpenRotation { get; private set; }
        [field : SerializeField] public Vector3 CloseRotation { get; private set;}

        [field : SerializeField] public float OpeningDuration { get; set; }
        public bool IsOpened { get; protected set; }
        public Action OnOpened { get; set; }
        public Action OnClosed { get; set; }

        private void Start()
        {
            transform.localRotation = IsOpened? Quaternion.Euler(OpenRotation):Quaternion.Euler(CloseRotation);
        }

        public virtual void Open()
        {
            transform.DOLocalRotate(OpenRotation, OpeningDuration).OnComplete(() =>
            {
                IsOpened = true;
                OnOpened?.Invoke();
            });
        }
        
        public virtual void Close()
        {
            transform.DOLocalRotate(CloseRotation, OpeningDuration).OnComplete(() =>
            {
                IsOpened = false;
                OnClosed?.Invoke();
            });
        }

        public virtual void Switch()
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