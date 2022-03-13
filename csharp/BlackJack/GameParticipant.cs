using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class GameParticipant
    {
        public List<Card> Hand { get; } = new List<Card>();

        public int TotalSum => Hand.Sum(c => c.CardPoints);
    }
}