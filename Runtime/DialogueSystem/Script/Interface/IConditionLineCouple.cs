namespace DialogueSystem
{
    public interface IConditionLineCouple
    {
        ILineCondition[] LineConditions { get; }
        bool IsLineUsable { get; }
        IDialogueLine Line { get; }
        IConditionLineCouple[] NextLines{ get; }
    }
}