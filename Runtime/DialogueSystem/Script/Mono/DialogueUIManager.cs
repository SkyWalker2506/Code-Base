using UnityEngine;

namespace DialogueSystem
{
    public class DialogueUIManager : MonoBehaviour, IDialogueUIManager
    {
        public static DialogueUIManager Instance;
        
        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        public void ShowLine(IDialogueLine dialogueLine)
        {
        }

        public void ShowChoices(IDialogueLine[] dialogueLines)
        {
        }
    }
}