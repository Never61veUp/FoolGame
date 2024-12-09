using FoolGame.Core.Model;

namespace FoolGame.Test.Core;

public class StackOfCardsTests
{
    [Fact]
    public void StackOfCard_InitializesDeckWith52UniqueCards()
    {
        var stackOfCard = new StackOfCard();
        
        var uniqueCards = new HashSet<Card>();
        while (stackOfCard.HasCards())
        {
            uniqueCards.Add(stackOfCard.GetCard());
        }
        
        Assert.Equal(36, uniqueCards.Count);
    }

    [Fact]
    public void GetCard_RemovesAndReturnsTopCard()
    {
        var stackOfCard = new StackOfCard();
        var initialCount = stackOfCard.RemainingCardsCount();
        
        var card = stackOfCard.GetCard();
        var finalCount = stackOfCard.RemainingCardsCount();
        
        Assert.NotNull(card);
        Assert.Equal(initialCount - 1, finalCount);
    }

    [Fact]
    public void PopCards_RemovesAndReturnsSpecifiedNumberOfCards()
    {
        var stackOfCard = new StackOfCard();
        var initialCount = stackOfCard.RemainingCardsCount();
        int cardsToPop = 5;
        
        var poppedCards = stackOfCard.PopCards(cardsToPop);
        var finalCount = stackOfCard.RemainingCardsCount();
        
        Assert.Equal(cardsToPop, poppedCards.Count);
        Assert.Equal(initialCount - cardsToPop, finalCount);
    }

    [Fact]
    public void PopCards_ThrowsException_WhenNotEnoughCards()
    {
        var stackOfCard = new StackOfCard();
        
        while (stackOfCard.RemainingCardsCount() > 2)
        {
            stackOfCard.GetCard();
        }
        
        Assert.Throws<InvalidOperationException>(() => stackOfCard.PopCards(5));
    }

    [Fact]
    public void ShuffleDeck_ProducesDifferentOrderEachTime()
    {
        var stackOfCard1 = new StackOfCard();
        var stackOfCard2 = new StackOfCard();
        
        var deck1 = stackOfCard1.PopCards(36);
        var deck2 = stackOfCard2.PopCards(36);
        
        Assert.NotEqual(deck1, deck2);
    }
}