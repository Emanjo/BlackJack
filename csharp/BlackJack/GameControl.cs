using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BlackJack
{
    public class GameControl
    {
        private readonly GameRulesService _gameRulesService;

        public GameParticipant Player { get; } = new GameParticipant();
        public GameParticipant Dealer { get; } = new GameParticipant();

        public Deck Deck { get; } = new Deck();

        public GameControl(GameRulesService gameSumService)
        {
            _gameRulesService = gameSumService;
        }

        public void RunGame()
        {
            var card = Deck.Cards.Dequeue();

            Dealer.Hand.Add(card);

            Console.WriteLine($"Game started!.. Dealers initial score is: {Dealer.TotalSum}");

            DrawPlayerCards();

            if (Player.TotalSum > 21)
            {
                Console.WriteLine("Dealer wins!");
                return;
            }

            DrawDealerCards();

            var winner = _gameRulesService.DetermineWinner(Dealer.TotalSum, Player.TotalSum);

            switch (winner)
            {
                case 1:
                    Console.WriteLine("Dealer wins!");
                    break;
                case 2:
                    Console.WriteLine("Player wins!");
                    break;
                default:
                    Console.WriteLine("Its a draw");
                    break;
            }
        }

        private void DrawPlayerCards()
        {
            Console.WriteLine("Player's turn...");

            while (true)
            {
                Console.WriteLine("Stand, Hit");

                string read = Console.ReadLine();

                if (read == "Hit")
                {
                    var card = Deck.Cards.Dequeue();

                    if (card.RankName == "A")
                    {
                        card.UpdateCardPoints(_gameRulesService.DeterminePointsForACard(Player.TotalSum));
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
                    card.UpdateCardPoints(_gameRulesService.DeterminePointsForACard(Player.TotalSum));
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
    }
}