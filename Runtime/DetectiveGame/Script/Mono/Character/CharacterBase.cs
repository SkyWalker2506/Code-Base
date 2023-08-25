using DetectiveGame.Interactable;
using DialogueSystem;

namespace DetectiveGame.Character
{
    public abstract class CharacterBase : InteractableBase, ITalkable
    {
        public IDialogueController DialogueController { get; private set; }
        protected override void Initialize()
        {
            DialogueController = new DialogueController();
        }
        
        public void Talk()
        {
            DialogueController.StartDialogue();
        }
    }
}