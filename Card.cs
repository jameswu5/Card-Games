using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames {
    public class Card {
        private int id;

        public Card(int id) {
            this.id = id;
        }

        public int GetValueBlackJack() {
            string rank = GetRank();
            return rank switch {
                "A" => 11,
                "T" => 10,
                "J" => 10,
                "Q" => 10,
                "K" => 10,
                _ => int.Parse(rank)
            };
        }

        public string GetRank() {
            int mask = 0b00001111;
            int value = id & mask;
            return value switch {
                1 => "A",
                10 => "T",
                11 => "J",
                12 => "Q",
                13 => "K",
                _ => value.ToString()
            };
        }
        
        public string GetSuit() {
            Dictionary<int, string> map = new() {
                {0b10000000, "♠"},
                {0b01000000, "♥"},
                {0b00100000, "♣"},
                {0b00010000, "♦"},
            };

            int mask = 0b11110000;
            int suit = id & mask;
            return map[suit];
        }

        public override string ToString()
        {
            return $"{GetRank()}{GetSuit()}";
        }

    }

}