namespace DialogueSystem
{
    public class DialogueController :  IDialogueController
    {
        public IDialogueData CurrentDialogueData { get; private set; }

        public bool IsDialogueAvailable => CurrentDialogueData.IsDialogueAvailable;
        
        public void SetDialogueData(IDialogueData dialogueData)
        {
            CurrentDialogueData = dialogueData;
        }

        public void StartDialogue()
        {
            if (!IsDialogueAvailable) { return; }
        }
    }
}