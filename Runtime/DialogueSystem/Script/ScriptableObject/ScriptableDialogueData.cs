#if UNITY_EDITOR
using UnityEditor;
#endif 
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(menuName = "DialogueSystem/ScriptableDialogueData", fileName = "ScriptableDialogueData", order = 0)]
    public class ScriptableDialogueData : ScriptableObject, IDialogueData
    {
        [field: SerializeField] public string Header { get; private set; }
        
        [SerializeField] private ScriptableConditionLineCouple[] startLines;

        public  IConditionLineCouple[] StartLines => startLines;
        
                
#if UNITY_EDITOR
        private void OnValidate()
        {
            string path = AssetDatabase.GetAssetPath(this);
            if (Header != null)
            {
                AssetDatabase.RenameAsset(path, $"{Header} DialogueData");
            }
            else
            {
                AssetDatabase.RenameAsset(path, "Empty DialogueData");
            }
        }
#endif 
    }
}