using System;

namespace BlackJack
{
    public class Card
    {
        public Suit Suit;
        public int Rank;

        public string RankDisplayName => GetRankDisplayName();

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
    }
}
