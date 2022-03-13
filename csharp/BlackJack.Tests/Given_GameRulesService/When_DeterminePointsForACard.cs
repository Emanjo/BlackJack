using NUnit.Framework;

namespace BlackJack.Tests.Game_Started
{
    public class When_DeterminePointsForACard : Scenario
    {
        private GameRulesService _gameRulesService;

        public override void Given()
        {
            _gameRulesService = new GameRulesService();
        }

        [Test]
        public void Should_determine_best_A_card_points()
        {
            Assert.AreEqual(1, _gameRulesService.DeterminePointsForACard(20));
            Assert.AreEqual(11, _gameRulesService.DeterminePointsForACard(0));
        }
    }
}
