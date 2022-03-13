using System;

namespace BlackJack
{
    public class Card
    {
        public Suit Suit { get; }
        public int Rank { get; }
        public int CardPoints { get; private set; }

        public string RankDisplayName => GetRankDisplayName();

        public Card(int rank, Suit suit)
        {
            Rank = rank;
            CardPoints = rank;
            Suit = suit;

            CardPoints = GetInitialCardPoints();
        }

        private int GetInitialCardPoints()
        {
            return Rank switch
            {
                1 => 1,
                11 => 10,
                12 => 10,
                13 => 10,
                _ => Rank,
            };
        }

        private string GetRankDisplayName()
        {
            return Rank switch
            {
                1 => "Ess",
                11 => "Knekt",
                12 => "Dame",
                13 => "Konge",
                _ => Rank.ToString(),
            };
        }

        public void UpdateCardPoints(int sum)
        {
            CardPoints = sum;
        }
    }
}
