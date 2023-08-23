#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Linq;
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(menuName = "DialogueSystem/ScriptableConditionLineCouple", fileName = "ScriptableConditionLineCouple", order = 0)]
    public class ScriptableConditionLineCouple : ScriptableObject, IConditionLineCouple
    {
        [SerializeField] private ScriptableLineConditionBase[] lineConditions;
        public ILineCondition[] LineConditions => lineConditions;
        public bool IsLineUsable => LineConditions.All(lc => lc.IsConditionMet());
        [SerializeField] private ScriptableDialogueLine line;
        public IDialogueLine Line => line;
        [SerializeField] private ScriptableConditionLineCouple[] nextLines;
        public IConditionLineCouple[] NextLines => nextLines;


#if UNITY_EDITOR
        private void OnValidate()
        {
            string path = AssetDatabase.GetAssetPath(this);
            if (line!=null)
            {
                AssetDatabase.RenameAsset(path, $"{line.name} ConditionLineCouple");
            }
            else
            {
                AssetDatabase.RenameAsset(path, "Empty ConditionLineCouple");
            }
        }
        #endif 
    }
}