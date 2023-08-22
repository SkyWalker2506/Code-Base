#if UNITY_EDITOR
using UnityEditor;
#endif        
using UnityEngine;
using UnityEngine.Events;

namespace DialogueSystem
{
    [CreateAssetMenu(menuName = "DialogueSystem/ScriptableDialogueLine", fileName = "ScriptableDialogueLine", order = 0)]
    public class ScriptableDialogueLine : ScriptableObject, IDialogueLine
    {
        [SerializeField] private ScriptableDialogueOwner owner;
        public IDialogueOwner Owner => owner;
        [field: SerializeField] public string Line { get; private set; }
        [field: SerializeField] public UnityEvent OnLineStarted { get;  private set;}
        [field: SerializeField] public UnityEvent OnLineEnded { get;  private set;}


        #if UNITY_EDITOR
        private void OnValidate()
        {
            string path = AssetDatabase.GetAssetPath(this);
            if (!string.IsNullOrWhiteSpace(Line))
            {
                AssetDatabase.RenameAsset(path, Line);
            }
            else
            {
                AssetDatabase.RenameAsset(path, "Empty Line");
            }
        }
        #endif        

    }
}