using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Tests.Given_GameSumService
{
    public class When_DetermineWinner : Scenario
    {
        private GameRulesService _gameSumService;

        public override void Given()
        {
            _gameSumService = new GameRulesService();
        }

        [Test]
        public void Should_determine_player_as_winner()
        {
            Assert.AreEqual(2, _gameSumService.DetermineWinner(22, 20));
            Assert.AreEqual(2, _gameSumService.DetermineWinner(17, 18));
            Assert.AreEqual(2, _gameSumService.DetermineWinner(3, 19));
        }

        [Test]
        public void Should_determine_dealer_as_winner()
        {
            Assert.AreEqual(1, _gameSumService.DetermineWinner(21, 20));
            Assert.AreEqual(1, _gameSumService.DetermineWinner(17, 14));
            Assert.AreEqual(1, _gameSumService.DetermineWinner(3, 24));
            Assert.AreEqual(1, _gameSumService.DetermineWinner(10, 9));
        }

        [Test]
        public void Should_be_draw()
        {
            Assert.AreEqual(0, _gameSumService.DetermineWinner(21, 21));
        }
    }
}
