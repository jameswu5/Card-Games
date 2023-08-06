using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack {
    public class Game {
        private CardCollection deck;

        private Player player;
        private Player splitPlayer;
        private Player dealer;

        private enum GameState {Playing, PlayerWins, DealerWins};
        private GameState gameState;

        public Game() {
            gameState = GameState.Playing;

            deck = new CardCollection(true);
            deck.Shuffle();

            player = new Player();
            splitPlayer = new Player();
            dealer = new Player();
        }

        private void DealHoleCards() {
            player.Hit(deck);
            player.Hit(deck);

            dealer.Hit(deck);
            dealer.Hit(deck);

        }

        public void PlayInteractiveGame() {
            while (player.score < 21) {
                player.Hit(deck);
                player.ShowHand();
            }
        }




    }
}