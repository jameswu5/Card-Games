using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGames {
    public class CardCollection {
        private List<Card> cards;

        public CardCollection(bool standardDeck = false) {
            cards = new List<Card>();
            if (standardDeck) {
                GenerateStandardDeck();
            }
        }

        public void AddCard(Card card) {
            cards.Add(card);
        }

        public Card DealCard() {
            if (IsEmpty()) {
                throw new Exception("The deck is empty");
            }
            Card topCard = cards[^1];
            cards.RemoveAt(cards.Count - 1);
            return topCard;
        }

        public Card MoveCard(CardCollection destination) {
            Card movedCard = DealCard();
            destination.AddCard(movedCard);
            return movedCard;
        } 

        public Card GetTopCard() {
            if (IsEmpty()) {
                throw new Exception("The deck is empty");
            }
            Card topCard = cards[^1];
            return topCard;
        }

        public void Clear() {
            cards.Clear();
        }

        public void GenerateStandardDeck() {
            Clear();
            int suit = 0b10000000;
            for (int i = 0; i < 4; i++) {
                for (int rank = 1; rank <= 13; rank++) {
                    AddCard(new Card(suit | rank));
                }
                suit >>= 1;
            }
        }

        public bool IsEmpty() {
            return cards.Count == 0;
        }

        public int GetCount() {
            return cards.Count;
        }

        // Fisher-Yates shuffle
        public void Shuffle() {
            Random rng = new();
            int n = cards.Count;
            while (n > 1) {
                n--;
                int k = rng.Next(n + 1);
                (cards[n], cards[k]) = (cards[k], cards[n]);
            }
        }

        public override string ToString() {
            StringBuilder sb = new();
            foreach (Card card in cards) {
                sb.Append(card.ToString());
                sb.Append(' ');
            }
            return sb.ToString();
        }
    }
}