using System.Collections.Generic;
using UnityEngine;

namespace TriggerSystem
{
    public class BoxOverlapTrigger<T> : OverlapTriggerBase<T> where T : MonoBehaviour
    {

        public BoxOverlapTrigger(IOverlapTriggerData overlapTriggerData) : base(overlapTriggerData)
        {
        }
        
        protected override HashSet<Collider> GetOverlapped()
        {
            Collider[] hitColliders = Physics.OverlapBox(CenterPosition, Vector3 .one*Size*.5f, CenterRotation, OverlapTriggerData.Layer);
            return new HashSet<Collider>(hitColliders);
        }

        public override void DrawGizmo()
        {
            Gizmos.color = OverlapTriggerData.GizmoColor;
            Gizmos.DrawWireCube(CenterPosition, Vector3 .one*Size);       
        }
    }

}