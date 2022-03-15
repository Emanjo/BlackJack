using System;
using System.Linq;
using NUnit.Framework;

namespace BlackJack.Tests.Given_Deck
{
    public class When_initialized : Scenario
    {
        private Deck _deck;
        public override void When()
        {
            _deck = new Deck();
        }

        [Test]
        public void Should_have_52_cards()
        {
            Assert.AreEqual(52, _deck.Cards.Count);
        }

        [Test]
        public void Should_have_4_distinct_suits()
        {
            Assert.AreEqual(4, _deck.Cards.Select(x => (int)x.Suit).Distinct().ToList().Count);
        }

        [Test]
        public void Should_have_correct_rankname()
        {
            Assert.IsTrue(_deck.Cards.Where(s => s.Rank == 1).All(c => c.RankName == "A"));
            Assert.IsTrue(_deck.Cards.Where(s => s.Rank == 11).All(c => c.RankName == "J"));
            Assert.IsTrue(_deck.Cards.Where(s => s.Rank == 12).All(c => c.RankName == "Q"));
            Assert.IsTrue(_deck.Cards.Where(s => s.Rank == 13).All(c => c.RankName == "K"));
            Assert.IsTrue(_deck.Cards.Where(s => s.Rank > 1 && s.Rank < 11).All(c => c.RankName == c.Rank.ToString()));
        }

        [Test]
        public void Should_have_correct_cardpoint()
        {
            Assert.IsTrue(_deck.Cards.Where(s => s.Rank < 10).All(c => c.CardPoints == c.Rank));
            Assert.IsTrue(_deck.Cards.Where(s => s.Rank > 10).All(c => c.CardPoints == 10));
        }
    }
}
