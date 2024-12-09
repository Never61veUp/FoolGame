using FoolGame.Core.enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolGame.Core.Model
{
    public class Card : IComparable<Card>
    {
        public Card(Suit suit, Rank rank, bool isTrumpCard = false)
        {
            Suit = suit;
            Rank = rank;
            IsTrumpCard = isTrumpCard;
        }
        
        public Suit Suit { get; }
        public Rank Rank { get; }
        public bool IsTrumpCard { get; set; }

        public override string ToString() => GetFirstCharOfSuit() + GetRankValue();

        private char GetFirstCharOfSuit() => Suit.ToString()[0];
        private string GetRankValue()
        {
            var rank = (int)Rank;
            return rank.ToString();
        }

        private int CompareRank(Card other)
        {
            if(this.Rank < other.Rank)
                return -1;
            if(this.Rank > other.Rank)
                return 1;
            return 0;
        }
        public int CompareTo(Card? other)
        {
            if (!IsTrumpCard)
            {
                return CompareRank(other);
            }
            else
            {
                return !other.IsTrumpCard ? 1 : CompareRank(other);
            }
        }
    }
}
