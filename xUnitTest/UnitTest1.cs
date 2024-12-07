using FoolGame.Core.enums;
using FoolGame.Core.Model;

namespace FoolGame.Test.Core
{
    public class UnitTest1
    {
        [Fact]
        public void Constructor_ShouldSetSuitAndRank()
        {
            var suit = Suit.Hearts;
            var rank = Rank.ACE;

            var card = new Card(suit, rank);

            Assert.Equal(suit, card.Suit);
            Assert.Equal(rank, card.Rank);
        }

        [Fact]
        public void ToString_ShouldReturnCorrectStringRepresentation()
        {
            var card = new Card(Suit.Spades, Rank.NINE);

            var result = card.ToString();

            Assert.Equal("S9", result);
        }

        [Fact]
        public void ToString_ShouldHandleFaceCardsCorrectly()
        {
            var card = new Card(Suit.Diamonds, Rank.KING);

            var result = card.ToString();

            Assert.Equal("D13", result);
        }
    }
}
