using System;

namespace BlackJack
{
    public class GameSumService
    {
        public int DeterminePointsForACard(int totalSum)
        {
            var totalPlusEssAsElleven = totalSum + 11;

            if (totalPlusEssAsElleven <= 21)
            {
                return 11;
            }

            return 1;
        }

        /// <summary>
        /// Determines the winner of the game
        /// </summary>
        /// <param name="dealerSum"></param>
        /// <param name="playerSum"></param>
        /// <returns>0 = draw, 1 = dealer, 2 = player</returns>
        public int DetermineWinner(int dealerSum, int playerSum)
        {
            if(playerSum > 21)
            {
                return 1;
            }

            if (dealerSum > 21 || Math.Abs(playerSum - 21) < Math.Abs(dealerSum - 21))
            {
                return 2;
            }

            if (dealerSum == playerSum)
            {
                return 0;
            }

            return 1;
        }
    }
}
