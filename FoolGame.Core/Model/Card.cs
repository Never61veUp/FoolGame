using FoolGame.Core.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolGame.Core.Model
{
    public class Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString() => GetFirstCharOfSuit() + GetRankValue();

        private char GetFirstCharOfSuit() => Suit.ToString()[0];
        private string GetRankValue()
        {
            var rank = (int)Rank;
            return rank.ToString();
        }


    }
}
