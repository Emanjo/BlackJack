using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            var hand = new List<Card>();

            while (true)
            {
                Console.WriteLine("Stand, Hit");
                string read = Console.ReadLine();
                if (read == "Hit")
                {
                    var card = deck.Cards.Dequeue();

                    if (card.RankName.ToLower() == "ess")
                    {
                        DeterminePointsForEss(hand, card);
                    }

                    hand.Add(card);

                    int total = GetSumForHand(hand);

                    if (total > 21)
                    {
                        Console.WriteLine("You lost...");
                        break;
                    }

                    Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, card.RankName, total);
                }
                else if (read == "Stand")
                {
                    break;
                }
            }
        }


        private static void DeterminePointsForEss(List<Card> hand, Card card)
        {
            var totalPlusEssAsElleven = GetSumForHand(hand) + 11;

            if(totalPlusEssAsElleven <= 21)
            {
                card.UpdateCardPoints(11);
            }
        }

        private static int GetSumForHand(List<Card> hand)
        {
            return hand.Sum(x => x.CardPoints);
        }
    }
}
