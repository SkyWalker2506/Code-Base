using UnityEngine;

namespace DebugSystem
{
    [CreateAssetMenu(fileName = "Debugger", menuName = "ScriptableDebugger ")]
    public class ScriptableDebugger : ScriptableObject
    {
        [SerializeField] bool showDebug;
        public void DebugLog(string log,GameObject obj=null)
        {
            if(showDebug)
                Debug.Log(log,obj);
        }

        public void DebugRaycastHitObject(RaycastHit hit)
        {
            DebugLog(hit.transform.name,hit.transform.gameObject);
        }
    }
}
