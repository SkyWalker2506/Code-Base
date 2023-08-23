#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace DialogueSystem
{
    [CreateAssetMenu(menuName = "DialogueSystem/ScriptableDialogueData", fileName = "ScriptableDialogueData", order = 0)]
    public class ScriptableDialogueData : ScriptableObject, IDialogueData
    {
        [field: SerializeField] public string Header { get; private set; }
        public IDialogueLine StartLine { get; }
        public bool IsDialogueAvailable => NextLines.Any(sl => sl.IsLineUsable);

        [SerializeField] private ScriptableConditionLineCouple[] nextLines;
        public  IConditionLineCouple[] NextLines => nextLines;
        
                
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