using System;

namespace InteractionSystem
{
    public interface IOpenable 
    {
        float OpeningDuration{get; set;}
        bool IsOpened{get;}
        Action OnOpened{get; set;}
        Action OnClosed{get; set;}
        void Initialize(bool isOpened);
        void Open();
        void Close();
    }
}
