namespace DialogueSystem
{
    public interface IDialogueData
    {
        string Header { get; }
        IConditionLineCouple[] StartLines{ get; }
    }
}