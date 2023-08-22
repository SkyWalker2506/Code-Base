using DetectiveGame.FiniteStateSystem;

namespace DetectiveGame.Character
{
    public class Cook : CharacterBase
    {
        private CookStateController cookStateController;
        protected override void Initialize()
        {
            cookStateController = new CookStateController(this);
        }
    }
}
