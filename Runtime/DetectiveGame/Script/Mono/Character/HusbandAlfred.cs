using DetectiveGame.FiniteStateSystem;

namespace DetectiveGame.Character
{
    public class HusbandAlfred : CharacterBase
    {
        private AlfredStateController alfredStateController;
        protected override void Initialize()
        {
            alfredStateController = new AlfredStateController(this);
        }
        
        
    }
}