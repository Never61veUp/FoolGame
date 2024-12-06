using FoolGame.Core.enums;
using FoolGame.Core.Model;

namespace FoolGame.Test.Core;

public class CardTest
{
    [Fact]
    public void Compare_NonTrumpCards_ReturnsCorrectComparison()
    {
        var card1 = new Card(Suit.Hearts, Rank.TEN);
        var card2 = new Card(Suit.Spades, Rank.EIGHT);
        
        int result = card1.CompareTo(card2);
        
        Assert.Equal(1, result); // card1 > card2 по рангу
    }

    [Fact]
    public void Compare_TrumpAndNonTrump_ReturnsCorrectComparison()
    {
        var card1 = new Card(Suit.Hearts, Rank.SEVEN, isTrumpCard: true);
        var card2 = new Card(Suit.Spades, Rank.ACE, isTrumpCard: false);
        
        int result = card1.CompareTo(card2);
        
        Assert.Equal(1, result); // card1 - козырная карта, должна быть выше
    }

    [Fact]
    public void Compare_BothTrumpCards_ReturnsCorrectComparison()
    {
        var card1 = new Card(Suit.Hearts, Rank.QUIN, isTrumpCard: true);
        var card2 = new Card(Suit.Hearts, Rank.KING, isTrumpCard: true);
        
        int result = card1.CompareTo(card2);
        
        Assert.Equal(-1, result); // card2 > card1 по рангу
    }
    [Fact]
    public void Compare_EqualCards_ReturnsCorrectComparison()
    {
        var card1 = new Card(Suit.Diamonds, Rank.TEN, isTrumpCard: false);
        var card2 = new Card(Suit.Hearts, Rank.TEN, isTrumpCard: false);
        
        int result = card1.CompareTo(card2);
        
        Assert.Equal(0, result); // card2 = card1 по рангу
    }

    [Fact]
    public void ToString_ReturnsCorrectFormat()
    {
        var card = new Card(Suit.Diamonds, Rank.JACK);
        
        string result = card.ToString();
        
        Assert.Equal("D11", result); // D для Diamonds, 11 для Jack
    }

}