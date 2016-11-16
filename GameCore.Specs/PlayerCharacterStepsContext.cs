using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    [Binding]
    public class PlayerCharacterStepsContext
    {
        public PlayerCharacter player { get; set; }

        public int StartingMagicalPower { get; set; }
    }
}