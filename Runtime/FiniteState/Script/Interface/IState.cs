using InteractionSystem;

namespace FiniteState
{
    public interface IState 
    {
        void OnStateEnter();
        void OnStateUpdate();
        void OnStateExit();
    }

    public interface IInteractableState : IState
    {
        Interaction Interaction { get; }
    }
    
    public class DoorOpenState : IInteractableState
    {
        public Interaction Interaction { get; }
        
        public DoorOpenState(DoorPanel doorPanel)
        {
            Interaction = new Interaction
            { 
                InteractionText = "Open",
                Interact = doorPanel.Open
            };
        }

        
        public void OnStateEnter()
        {
            Interaction.Interact();
        }

        public void OnStateUpdate()
        {
        }

        public void OnStateExit()
        {
        }

    }
}
