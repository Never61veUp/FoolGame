using FoolGame.Core.enums;
using static System.Enum;

namespace FoolGame.Core.Model;

public class StackOfCard : IStackOfCard
{
    private const int DECK_COUNT = 36;
    
    private readonly Stack<Card> _stack = [];
    private readonly List<Card> _listOfCards = [];
    private readonly Random _random = new Random();

    public StackOfCard()
    {
        InitializeDeck();
    }
    public int RemainingCardsCount() => _stack.Count;

    public Card GetCard()
    {
        if (!HasCards())
            throw new InvalidOperationException("No cards left in the stack.");
        return _stack.Pop();
    }
    public bool HasCards() => _stack.Count > 0;

    public List<Card> PopCards(int count)
    {
        if (_stack.Count < count)
            throw new InvalidOperationException("Not enough cards in the stack.");
        
        var result = new List<Card>();
        
        for (int i = 0; i < count; i++)
        {
            result.Add(_stack.Pop());
        }
        
        return result;
    }
    
    public void InitializeDeck()
    {
        if (_listOfCards.Count != 0) return;
        
        foreach (var suit in GetValues<Suit>())
        foreach (var value in GetValues<Rank>())
            _listOfCards.Add(new Card(suit, value));

        ShuffleDeck();
    }
    private void ShuffleDeck()
    {
        var trumpIndex = _random.Next(_listOfCards.Count);
        SetTrumpCardAndPushToStack(trumpIndex);
        
        while (_listOfCards.Count > 0)
        {
            var cardIndex = _random.Next(_listOfCards.Count);
            _stack.Push(_listOfCards[cardIndex]);
            _listOfCards.RemoveAt(cardIndex);
        }
    }
    private void SetTrumpCardAndPushToStack(int currentCardIndex)
    {
        var trumpCard = _listOfCards[currentCardIndex];
        foreach (var card in _listOfCards)
        {
            if(card.Suit == trumpCard.Suit)
                card.IsTrumpCard = true;
        }
        _stack.Push(_listOfCards[currentCardIndex]);
        _listOfCards.Remove(_listOfCards[currentCardIndex]); 
    }

}