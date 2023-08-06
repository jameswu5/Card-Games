using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack {
    public class Program {
        public static void Main() {
            Card card = new Card(0b01001010);
            Console.WriteLine(card);
            Console.WriteLine(card.GetValueBlackJack());
        }
    }
}