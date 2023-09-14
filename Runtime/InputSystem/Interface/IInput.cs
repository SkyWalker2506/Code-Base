using UnityEngine;

namespace InputSystem
{
    public interface IInput 
    {
        Vector3 Input { get; }
        void UpdateInput();
    }
    
}
