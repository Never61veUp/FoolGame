using FoolGame.Core.Abstractions;
using FoolGame.Core.enums;
using FoolGame.Core.Model;
using Moq;

namespace FoolGame.Test.Core;

public class DeskTests
{
    [Fact]
    public void AddNewCard_Should_AddCardToDesk()
    {
        // Arrange
        var cardCoveringServiceMock = new Mock<ICardCoveringService>();
        var desk = new Desk(cardCoveringServiceMock.Object);
        var card = new Card(Suit.Hearts, Rank.KING);

        // Act
        desk.AddNewCard(card);

        // Assert
        var result = desk.PopAllCardsFromDesk();
        Assert.Single(result);
        Assert.Equal(card, result[0]);
    }

    [Fact]
    public void PopAllCardsFromDesk_Should_ReturnAllCardsAndClearDesk()
    {
        // Arrange
        var cardCoveringServiceMock = new Mock<ICardCoveringService>();
        var desk = new Desk(cardCoveringServiceMock.Object);
        var card1 = new Card(Suit.Hearts, Rank.KING);
        var card2 = new Card(Suit.Spades, Rank.QUIN);

        desk.AddNewCard(card1);
        desk.AddNewCard(card2);

        // Act
        var result = desk.PopAllCardsFromDesk();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(card1, result);
        Assert.Contains(card2, result);

        // Ensure desk is empty
        Assert.Empty(desk.PopAllCardsFromDesk());
    }

    [Fact]
    public void CoverCard_Should_CallCoverCardService()
    {
        // Arrange
        var cardCoveringServiceMock = new Mock<ICardCoveringService>();
        var desk = new Desk(cardCoveringServiceMock.Object);
        var cardOnDesk = new Card(Suit.Hearts, Rank.KING);
        var cardInHand = new Card(Suit.Spades, Rank.ACE);

        desk.AddNewCard(cardOnDesk);

        // Act
        desk.CoverCard(cardInHand, cardOnDesk);

        // Assert
        cardCoveringServiceMock.Verify(
            x => x.CoverCard(cardInHand, cardOnDesk, It.IsAny<Stack<Card>>()),
            Times.Once
        );
    }
}