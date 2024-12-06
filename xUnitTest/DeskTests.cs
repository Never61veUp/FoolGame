using FoolGame.Core.enums;
using FoolGame.Core.Model;

namespace FoolGame.Test.Core;

public class DeskTests
{
    [Fact]
    public void PopAllCardsFromDesk_ReturnsAllCardsAndClearsDesk()
    {
        // Arrange
        var desk = new Desk();
        var stack1 = new Stack<Card>();
        stack1.Push(new Card(Suit.Hearts, Rank.TEN));
        var stack2 = new Stack<Card>();
        stack2.Push(new Card(Suit.Spades, Rank.EIGHT));

        // Добавляем карты на стол (через рефлексию, если поле приватное)
        var stacksField = typeof(Desk).GetField("_cardStacks", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        stacksField.SetValue(desk, new List<Stack<Card>> { stack1, stack2 });

        // Act
        var result = desk.PopAllCardsFromDesk();

        // Assert
        Assert.Equal(2, result.Count); // Должны вернуть все карты
        Assert.Empty((List<Stack<Card>>)stacksField.GetValue(desk)); // Список стеков должен быть очищен
    }

    [Fact]
    public void CoverCard_AddsCardToStack_WhenConditionsAreMet()
    {
        // Arrange
        var desk = new Desk();
        var stack = new Stack<Card>();
        var cardOnDesk = new Card(Suit.Hearts, Rank.SEVEN);
        stack.Push(cardOnDesk);

        var cardInHand = new Card(Suit.Hearts, Rank.EIGHT); // Более высокая карта
        var stacksField = typeof(Desk).GetField("_cardStacks", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        stacksField.SetValue(desk, new List<Stack<Card>> { stack });

        // Act
        var coverCardMethod = typeof(Desk).GetMethod("CoverCard", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        coverCardMethod.Invoke(desk, new object[] { cardInHand, cardOnDesk });

        // Assert
        Assert.Equal(2, stack.Count); // Карта добавлена
        Assert.Equal(cardInHand, stack.Peek()); // Верхняя карта - карта из руки
    }

    [Fact]
    public void CoverCard_DoesNotAddCard_WhenConditionsAreNotMet()
    {
        // Arrange
        var desk = new Desk();
        var stack = new Stack<Card>();
        var cardOnDesk = new Card(Suit.Hearts, Rank.SEVEN);
        stack.Push(cardOnDesk);

        var cardInHand = new Card(Suit.Spades, Rank.SIX); // Не подходит по масти
        var stacksField = typeof(Desk).GetField("_cardStacks",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        stacksField.SetValue(desk, new List<Stack<Card>> { stack });

        // Act
        var coverCardMethod = typeof(Desk).GetMethod("CoverCard",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        coverCardMethod.Invoke(desk, new object[] { cardInHand, cardOnDesk });

        // Assert
        Assert.Single(stack); // Карта не добавлена
        Assert.Equal(cardOnDesk, stack.Peek()); // Верхняя карта не изменилась
    }
    
    [Fact]
    public void AddNewCard_AddsNewStackWithCard()
    {
        // Arrange
        var desk = new Desk();
        var card = new Card(Suit.Hearts, Rank.ACE);

        // Act
        desk.AddNewCard(card);

        // Проверяем через рефлексию, если _cardStacks приватное поле
        var stacksField = typeof(Desk).GetField("_cardStacks", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var stacks = (List<Stack<Card>>)stacksField.GetValue(desk);

        // Assert
        Assert.Single(stacks); // Должен быть один стек
        Assert.Single(stacks[0]); // В этом стеке должна быть одна карта
        Assert.Equal(card, stacks[0].Peek()); // Верхняя карта должна совпадать с добавленной
    }
}