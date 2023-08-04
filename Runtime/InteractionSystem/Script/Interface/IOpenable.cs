using System;

namespace InteractionSystem
{
    public interface IOpenable 
    {
        float OpenDuration{get; set;}
        bool IsOpened{get; set;}
        Action OnOpened{get; set;}
        Action OnClosed{get; set;}
        void Open();
        void Close();
    }
}
