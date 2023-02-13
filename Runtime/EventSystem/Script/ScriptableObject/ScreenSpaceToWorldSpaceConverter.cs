using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.EventSystem.MouseEvent
{
    [CreateAssetMenu(menuName = "ScreenSpaceToWorldSpaceConverter")]
    public class ScreenSpaceToWorldSpaceConverter : ScriptableObject
    {
        [SerializeField] UnityEvent<Vector3> onScreenspaceToWorldSpace;
        public void ScreenSpaceToWorldSpace(Vector2 screenSpace)
        {
            onScreenspaceToWorldSpace?.Invoke(Camera.main.ScreenToWorldPoint(new Vector3(screenSpace.x, screenSpace.y,Camera.main.nearClipPlane)));
        }
    }
}