using TechTalk.SpecFlow;

namespace GameCore.Specs
{

    [Binding]
    public class CommonPlayerCharacterSteps : TechTalk.SpecFlow.Steps
    {
        private readonly PlayerCharacterStepsContext _context;

        public CommonPlayerCharacterSteps(PlayerCharacterStepsContext context) {

            _context = context;


        }

        [Given(@"I am new player")]
        public void GivenIAmNewPlayer() {
            _context.player = new PlayerCharacter();
        }
    }
}