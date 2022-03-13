using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameControl = new GameControl();

            gameControl.StartGame();
        }
    }
}
