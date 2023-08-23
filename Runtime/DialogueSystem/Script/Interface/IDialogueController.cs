namespace DialogueSystem
{
    public interface IDialogueController
    {
        IDialogueData CurrentDialogueData{ get; }
        bool IsDialogueAvailable{ get; }
        void SetDialogueData(IDialogueData dialogueData);
        void StartDialogue();
    }
}