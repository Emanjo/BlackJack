using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        public Queue<Card> Cards;

        public Deck()
        {
            PopulateDeck();
        }

        private void PopulateDeck()
        {
            Cards = new Queue<Card>();

            foreach (var card in GetShuffledCards())
            {
                Cards.Enqueue(card);
            }
        }

        private static List<Card> GetShuffledCards()
        {
            var listOfCards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int i = 1; i < 14; i++)
                {
                    listOfCards.Add(new Card(rank: i, suit: suit));
                }
            }

            var randomizer = new Random();

            return listOfCards.OrderBy(c => randomizer.Next()).ToList();
        }
    }
}
