using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack {
    public class Program {
        public static void Main() {
            CardCollection deck = new CardCollection(true);
            deck.Shuffle();
            Console.WriteLine(deck);
            Card card = deck.DealCard();
            Console.WriteLine(deck);
            Console.WriteLine(card);
        }
    }
}