using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames.Patience {
    public class Game {

        private CardCollection deck;
        
        public Game() {
            deck = new CardCollection(true);
            deck.Shuffle();
        }

        public List<CardCollection> Simulate(bool slowMode = false) {
            List<CardCollection> piles = new();

            CardCollection pile = new();
            deck.MoveCard(pile);
            piles.Add(pile);

            while (!deck.IsEmpty()) {

                if (slowMode) {
                    foreach (CardCollection p in piles) {
                        Console.WriteLine(p);
                    }
                    Console.WriteLine();
                    Console.ReadKey();
                }

                Card card = deck.DealCard();
                int cardValue = card.GetValue();

                // binary search the pile to put the card in
                int l = 0;
                int r = piles.Count;
                while (l != r) {
                    int m = (l + r) / 2;
                    if (piles[m].GetTopCard().GetValue() >= cardValue) {
                        r = m;
                    } else {
                        l = m + 1;
                    }
                }

                if (l == piles.Count) {
                    CardCollection newPile = new();
                    piles.Add(newPile);
                }

                piles[l].AddCard(card);
            }

            Console.WriteLine("Piles:");
            foreach (CardCollection p in piles) {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            return piles;
        }

        public void PatienceSort() {
            Console.WriteLine($"Unsorted deck:");
            Console.WriteLine(deck);
            Console.WriteLine();
            List<CardCollection> piles = Simulate();

            CardCollection sortedDeck = new();

            while (sortedDeck.GetCount() < 52) {
                int minValue = 14;
                CardCollection pile = null!;
                for (int i = 0; i < piles.Count; i++) {
                    if (!piles[i].IsEmpty() && piles[i].GetTopCard().GetValue() < minValue) {
                        minValue = piles[i].GetTopCard().GetValue();
                        pile = piles[i];
                    }
                }
                pile.MoveCard(sortedDeck);
            }

            Console.WriteLine($"Sorted deck");
            Console.WriteLine(sortedDeck);
        }
    }
}