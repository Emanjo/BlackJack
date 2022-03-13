using NUnit.Framework;

namespace BlackJack.Tests.Game_Started
{
    public class When_DeterminePointsForACard : Scenario
    {
        private GameSumService _gameSumService;

        public override void Given()
        {
            _gameSumService = new GameSumService();
        }

        [Test]
        public void Should_determine_best_A_card_points()
        {
            Assert.AreEqual(1, _gameSumService.DeterminePointsForACard(20));
            Assert.AreEqual(11, _gameSumService.DeterminePointsForACard(0));
        }
    }
}
