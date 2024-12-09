using FoolGame.Core.Abstractions;
using FoolGame.Core.enums;
using FoolGame.Core.Model;
using Moq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace FoolGame.Test.Core.Model;
public class PlayerMoqTest
{
    [Fact]
    public void Create_ShouldReturnPlayerWithCorrectUsername()
    {
        // Arrange
        var mockCardCollection = new Mock<ICardCollection>();
        var username = "TestPlayer";

        // Act
        var player = Player.Create(username, mockCardCollection.Object);

        // Assert
        Assert.NotNull(player);
        Assert.Equal(username, player.Username);
        Assert.Empty(player.Cards);
    }
    [Fact]
    public void AddCards_ShouldAddCardsToCollection()
    {
        // Arrange
        var mockCardCollection = new Mock<ICardCollection>();
        var player = Player.Create("TestPlayer", mockCardCollection.Object);
        var cardsToAdd = new List<Card>
        {
            new Card(Suit.Clubs, Rank.SEVEN),
            new Card(Suit.Diamonds, Rank.EIGHT)
        };

        // Act
        player.AddCards(cardsToAdd);

        var a = player.Cards;
        // Assert
        mockCardCollection.Verify(cc => cc.AddCards(cardsToAdd), Times.Once);
    }
    [Fact]
    public void RemoveCard_ShouldRemoveSpecifiedCardFromCollection()
    {
        // Arrange
        var mockCardCollection = new Mock<ICardCollection>();
        var player = Player.Create("TestPlayer", mockCardCollection.Object);
        var cardToRemove = new Card(Suit.Clubs, Rank.ACE);

        // Act
        player.RemoveCard(cardToRemove);

        // Assert
        mockCardCollection.Verify(cc => cc.RemoveCard(cardToRemove), Times.Once);
    }
    [Fact]
    public void GetHighestCard_ShouldReturnHighestCardFromCollection()
    {
        // Arrange
        var mockCardCollection = new Mock<ICardCollection>();
        var highestCard = new Card(Suit.Spades, Rank.ACE);
        mockCardCollection.Setup(cc => cc.GetHighestCard()).Returns(highestCard);
        var player = Player.Create("TestPlayer", mockCardCollection.Object);

        // Act
        var result = player.GetHighestCard();

        // Assert
        Assert.Equal(highestCard, result);
        mockCardCollection.Verify(cc => cc.GetHighestCard(), Times.Once);
    }
    
    
}