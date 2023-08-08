using System.Collections.Generic;

namespace InteractionSystem
{
    public interface IInspectable 
    {
        List<IInteractable> InspectInteractables{ get; }
        void Inspect();
    }
}