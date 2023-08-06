using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack {
    public class Player {
        private CardCollection hand;
        public int score;
        public int soft;

        public Player() {
            hand = new CardCollection();
            score = 0;
            soft = 0;
        }

        public bool CheckIsBust() {
            return score > 21;
        }

        public void Hit(CardCollection sourceDeck) {
            Card card = sourceDeck.DealCard();
            hand.AddCard(card);
            score += card.GetValueBlackJack();

            if (card.GetRank() == "A") {
                soft++;
            }
            
            // convert aces to score 1 to prevent busting
            if (score > 21 && soft > 0) {
                score -= 10;
                soft--;
            }
        }

        public void Split(Player split) {
            split.Hit(hand); // deal a card to the split player
            score /= 2; // halve the score
        }


        public void ShowHand() {
            Console.WriteLine($"Score: {score} | {hand}");
        }

    }
}