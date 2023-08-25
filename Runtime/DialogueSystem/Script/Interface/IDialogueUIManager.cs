namespace DialogueSystem
{
    public interface IDialogueUIManager
    {
        IDialogueChoice DialogueChoicePrefab { get; }
        void ShowLine(IDialogueLine dialogueLine);
        void HideLine();
        void ShowChoices(IDialogueLine[] dialogueLines);
        void HideChoices();

    }
}