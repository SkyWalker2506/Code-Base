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

        [field : SerializeField] public float OpenDuration { get; set; }
        public bool IsOpened { get; set; }
        public Action OnOpened { get; set; }
        public Action OnClosed { get; set; }

        public virtual void Open()
        {
            transform.DORotate(OpenRotation, OpenDuration).OnComplete(() =>
            {
                IsOpened = true;
                OnOpened?.Invoke();
            });
        }
        
        public virtual void Close()
        {
            transform.DORotate(CloseRotation, OpenDuration).OnComplete(() =>
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