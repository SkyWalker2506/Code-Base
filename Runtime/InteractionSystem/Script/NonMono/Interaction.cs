using System;
using System.Numerics;

namespace InteractionSystem
{
    public struct Interaction
    {
        public string InteractionText{ get; set; }
        public Action Interact{ get; set; }
    }
    
}