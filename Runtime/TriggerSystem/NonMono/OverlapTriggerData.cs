using System;
using UnityEngine;

namespace TriggerSystem
{
    [Serializable]
    public struct OverlapTriggerData : IOverlapTriggerData
    {
        public Vector3 Center { get; }
        public Quaternion Rotation { get;}
        public Vector3 Offset { get; }
        public float Size { get; }
        public LayerMask Layer { get; }
        public Color GizmoColor { get; }
    }
}