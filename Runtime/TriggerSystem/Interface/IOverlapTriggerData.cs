using UnityEngine;

namespace TriggerSystem
{
    public interface IOverlapTriggerData
    {
        Vector3 Center { get; }
        Quaternion Rotation { get; }
        Vector3 Offset { get; }
        float Size { get; }
        LayerMask Layer { get; }
        Color GizmoColor { get; }
    }
}