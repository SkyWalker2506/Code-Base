using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueUIManager : MonoBehaviour, IDialogueUIManager
    {
        [SerializeField] private GameObject dialogueLineArea;
        [SerializeField] private TMP_Text dialogueText;
        [SerializeField] private GameObject dialogueChoiceArea;
        [SerializeField] private DialogueChoice dialogueChoicePrefab;
        public IDialogueChoice DialogueChoicePrefab => dialogueChoicePrefab;
        [SerializeField] private Transform dialogueChoiceHolder;
        private List<IDialogueChoice> dialogueChoices = new();
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
            dialogueText.SetText(dialogueLine.Line);
            dialogueLineArea.SetActive(true);
        }

        public void HideLine()
        {
            dialogueLineArea.SetActive(false);
        }

        public void ShowChoices(IDialogueLine[] dialogueLines)
        {
            if (dialogueChoices.Count < dialogueLines.Length)
            {
                for (int i = dialogueChoices.Count; i < dialogueLines.Length; i++)
                {
                    dialogueChoices.Add(Instantiate(dialogueChoicePrefab,dialogueChoiceHolder));
                }
            }

            for (int i = 0; i < dialogueChoices.Count; i++)
            {
                if (i < dialogueLines.Length)
                {
                    dialogueChoices[i].SetChoiceText(dialogueLines[i].Line, i);
                }
            }
            
            dialogueChoiceArea.SetActive(true);
        }

        public void HideChoices()
        {
            dialogueChoiceArea.SetActive(false);
        }
    }
}