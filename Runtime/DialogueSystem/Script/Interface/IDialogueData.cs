namespace DialogueSystem
{
    public interface IDialogueData
    {
        string Header { get; }
        IDialogueLine StartLine{ get; }
        bool IsDialogueAvailable { get; }
        IConditionLineCouple[] NextLines{ get; }
    }
}