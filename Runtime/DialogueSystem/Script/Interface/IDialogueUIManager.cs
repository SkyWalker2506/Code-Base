namespace DialogueSystem
{
    public interface IDialogueUIManager
    {
        void ShowLine(IDialogueLine dialogueLine);
        void ShowChoices(IDialogueLine[] dialogueLines);

    }
}