namespace DialogueSystem
{
    public class DialogueManager : IDialogueManager
    {
        public IDialogueUIManager IDialogueUIManager => DialogueUIManager.Instance;
        public IDialogueLine CurrentLine { get; private set; }

        public void StartDialogue(IDialogueData dialogueData)
        {
            CurrentLine = dialogueData.StartLine;
            StartCurrentLine();
        }

        void StartCurrentLine()
        {
            CurrentLine.OnLineEnded.AddListener(OnLineEnded);
            CurrentLine.OnLineStarted?.Invoke();
            IDialogueUIManager.ShowLine(CurrentLine);
        }
        
        void OnLineEnded()
        {
            CurrentLine.OnLineEnded.RemoveListener(OnLineEnded);
            /*if no line Stop dialogue
             if one line move to the next line and call StartCurrentLine()
             if more then one line for player show choices
             */
        }
        
    }
}