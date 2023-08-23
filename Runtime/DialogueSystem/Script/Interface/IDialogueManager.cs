using System;

namespace DialogueSystem
{
    public interface IDialogueManager
    {
        IDialogueUIManager IDialogueUIManager { get; }
        IDialogueLine CurrentLine{ get; }
        void StartDialogue(IDialogueData dialogueData);
    }
}