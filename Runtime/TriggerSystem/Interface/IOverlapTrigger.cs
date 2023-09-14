using System;
using System.Collections.Generic;
using UnityEngine;

namespace TriggerSystem
{
    public interface IOverlapTrigger<T> where T : MonoBehaviour
    {
        IOverlapTriggerData OverlapTriggerData{ get; }
        HashSet<Collider> OverlappedObjects{ get; }
        Action<T> OnTriggerEnter { get; set; }
        Action<T> OnTriggerStay { get; set; }
        Action<T> OnTriggerExit { get; set; }
        void Update();
        void DrawGizmo();

    }
}