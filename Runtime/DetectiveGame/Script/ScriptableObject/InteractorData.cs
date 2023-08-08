using UnityEngine;

namespace DetectiveGame.InteractionSystem
{
    [CreateAssetMenu(menuName = "Create InteractorData", fileName = "InteractorData", order = 0)]
    public class InteractorData : ScriptableObject
    {
        [field: SerializeField] public LayerMask InteractableLayerMask{ get; private set; }

        [field: SerializeField] public float CheckAngle { get; private set; }
        [field: SerializeField] public float CheckRadius { get; private set; }
        [field: SerializeField] public float CheckIntervalMS { get; private set; }
    }
}