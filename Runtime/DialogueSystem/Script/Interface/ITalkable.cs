
namespace DialogueSystem
{
    public interface ITalkable
    {
        IDialogueController DialogueController { get; } 
        void Talk();
    }
}
