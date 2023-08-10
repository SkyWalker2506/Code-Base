using System;
using System.Collections.Generic;

namespace InteractionSystem
{
    public interface IInspectable 
    {
        List<IInteractable> InspectInteractables{ get; }
        void Inspect();
        Action OnInspect{get; set;}
        Action OnInspectEnded{get; set;}
    }
}