using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames.Blackjack {
    public class Game {
        private CardCollection deck;

        private Player player;
        private Player splitPlayer;
        private Player dealer;

        private enum GameState {Playing, PlayerWins, DealerWins, Draw};
        private enum Choice {Hit, Stand};
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
            DealHoleCards();

            Console.WriteLine("Dealer's hand:");
            dealer.ShowHiddenHand();

            while (gameState == GameState.Playing) {
                Console.WriteLine();
                Console.WriteLine("Your hand:");
                player.ShowHand();

                // implement splitting later
                Choice choice = Choice.Hit;
                while (!player.CheckIsBust() && choice == Choice.Hit) {
                    Console.WriteLine();
                    Console.Write("Would you like to hit (1) or stand (2)? ");
                    int option = int.Parse(Console.ReadLine());
                    if (option == 2) {
                        choice = Choice.Stand;
                    } else {
                        player.Hit(deck);
                        Console.WriteLine("You hit");
                        player.ShowHand();
                    }
                }
                if (player.CheckIsBust()) {
                    Console.WriteLine("You are bust!");
                    gameState = GameState.DealerWins;
                } else {
                    Console.WriteLine();
                    Console.WriteLine("Dealer's hand:");
                    dealer.ShowHand();
                    while (dealer.score < 17) {
                        dealer.Hit(deck);
                        dealer.ShowHand();
                    }
                    if (dealer.CheckIsBust()) {
                        Console.WriteLine("The dealer is bust!");
                        gameState = GameState.PlayerWins;
                    } else {
                        if (dealer.score > player.score) {
                            gameState = GameState.DealerWins;
                        } else if (player.score > dealer.score) {
                            gameState = GameState.PlayerWins;
                        } else {
                            gameState = GameState.Draw;
                        }
                    }
                }
            }

            Console.WriteLine();

            switch (gameState) {
                case GameState.PlayerWins:
                    Console.WriteLine("You win the round!");
                    break;
                case GameState.DealerWins:
                    Console.WriteLine("The dealer wins this round.");
                    break;
                case GameState.Draw:
                    Console.WriteLine("It is a draw.");
                    break;
                default:
                    Console.WriteLine("Something wrong has happened.");
                    break;
            }

        }
    }
}