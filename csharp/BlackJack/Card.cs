using System;

namespace BlackJack
{
    public class Card
    {
        public Suit Suit { get; }
        public int Rank { get; }
        public int CardPoints { get; private set; }
        public string RankName => Rank switch
        {
            1 => "Ess",
            11 => "Knekt",
            12 => "Dame",
            13 => "Konge",
            _ => Rank.ToString(),
        };

        public Card(int rank, Suit suit)
        {
            Rank = rank;
            CardPoints = rank;
            Suit = suit;

            CardPoints = GetInitialCardPoints();
        }

        private int GetInitialCardPoints() => Rank switch
        {
            1 => 1,
            11 => 10,
            12 => 10,
            13 => 10,
            _ => Rank,
        };

        public void UpdateCardPoints(int sum)
        {
            CardPoints = sum;
        }
    }
}
