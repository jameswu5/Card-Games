using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames.Patience {
    public class Game {
        private CardCollection deck;
        private List<CardCollection> piles;
        
        public Game() {
            deck = new CardCollection(true);
            deck.Shuffle();
            piles = new List<CardCollection>();
            Console.WriteLine(deck);
        }

        public void Simulate(bool slowMode = false) {
            CardCollection pile = new CardCollection();
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

                // binary search the pile to put the card in
                int l = 0;
                int r = piles.Count;
                while (l != r) {
                    int m = (l + r) / 2;
                    if (piles[m].GetTopCard().GetValue() > card.GetValue()) {
                        l = m + 1;
                    } else {
                        r = m;
                    }
                }

                if (l == piles.Count) {
                    CardCollection newPile = new();
                    piles.Add(newPile);
                }

                piles[l].AddCard(card);
            }

            foreach (CardCollection p in piles) {
                Console.WriteLine(p);
            }
        }
    }
}