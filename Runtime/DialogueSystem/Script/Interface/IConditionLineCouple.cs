namespace DialogueSystem
{
    public interface IConditionLineCouple
    {
        ILineCondition[] LineConditions { get; }
        IDialogueLine Line{ get; }
        IConditionLineCouple[] NextLines{ get; }
    }
}