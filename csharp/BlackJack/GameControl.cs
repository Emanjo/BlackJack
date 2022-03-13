using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BlackJack
{
    public class GameControl
    {
        public GameParticipant Player { get; } = new GameParticipant();
        public GameParticipant Dealer { get; } = new GameParticipant();

        public Deck Deck { get; } = new Deck();

        public void RunGame()
        {
            var card = Deck.Cards.Dequeue();

            Dealer.Hand.Add(card);

            Console.WriteLine($"Game started!.. Dealers initial score is: {Dealer.TotalSum}");

            DrawPlayerCards();

            if (Player.TotalSum > 21)
            {
                Console.WriteLine("You lost...");
                return;
            }

            DrawDealerCards();

            DetermineWinner();
        }

        private void DetermineWinner()
        {
            if(Dealer.TotalSum > 21 || Math.Abs(Player.TotalSum - 21) < Math.Abs(Dealer.TotalSum - 21))
            {
                Console.WriteLine("You win!");
                return;
            }

            if(Dealer.TotalSum == Player.TotalSum)
            {
                Console.WriteLine("Its a draw.");
                return;
            }

            Console.WriteLine("You lost!");
        }

        private void DrawPlayerCards()
        {
            Console.WriteLine("Your turn...");

            while (true)
            {
                Console.WriteLine("Stand, Hit");

                string read = Console.ReadLine();

                if (read == "Hit")
                {
                    var card = Deck.Cards.Dequeue();

                    if (card.RankName == "A")
                    {
                        DeterminePointsForEss(Player, card);
                    }

                    Player.Hand.Add(card);

                    Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, card.RankName, Player.TotalSum);
                    
                    if (Player.TotalSum > 21)
                    {
                        break;
                    }
                }
                else if (read == "Stand")
                {
                    break;
                }
            }
        }

        private void DrawDealerCards()
        {
            Console.WriteLine("The dealer draws cards..");

            while (true)
            {
                var card = Deck.Cards.Dequeue();

                if (card.RankName == "A")
                {
                    DeterminePointsForEss(Player, card);
                }

                Dealer.Hand.Add(card);

                Console.WriteLine("Dealer got {0} {1}. Total is {2}", card.Suit, card.RankName, Dealer.TotalSum);

                Thread.Sleep(500);

                if (Dealer.TotalSum >= 17)
                {
                    break;
                }
            }
        }

        private static void DeterminePointsForEss(GameParticipant player, Card card)
        {
            var totalPlusEssAsElleven = player.TotalSum + 11;

            if (totalPlusEssAsElleven <= 21)
            {
                card.UpdateCardPoints(11);
            }
        }
    }
}