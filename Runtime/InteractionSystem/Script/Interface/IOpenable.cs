using System;

namespace InteractionSystem
{
    public interface IOpenable 
    {
        float OpeningDuration{get; set;}
        bool IsOpened{get; set;}
        Action OnOpened{get; set;}
        Action OnClosed{get; set;}
        void Open();
        void Close();
    }
}
