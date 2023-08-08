using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames {
    public class Program {
        public static void Main() {
            Patience.Game game = new();
            game.Simulate(true);
            // Blackjack.Game game = new();
            // game.PlayInteractiveGame();
        }
    }
}