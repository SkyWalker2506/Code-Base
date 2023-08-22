using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(menuName = "DialogueSystem/ScriptableDialogueOwner", fileName = "ScriptableDialogueOwner", order = 0)]
    public class ScriptableDialogueOwner : ScriptableObject, IDialogueOwner
    {
        [field: SerializeField] public string Name { get; private set; }
    }
}