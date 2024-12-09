using FoolGame.Core.enums;
using static System.Enum;

namespace FoolGame.Core.Model;

public class StackOfCard : IStackOfCard
{
    private const int DECK_COUNT = 36;
    
    private readonly Stack<Card> _stack = [];
    private readonly List<Card> _listOfCards = [];

    public StackOfCard()
    {
        InitializeDeck();
    }
    public int RemainingCardsCount() => _stack.Count;
    public Card GetCard() => _stack.Pop();
    public bool HasCards() => _stack.Count > 0;

    public List<Card> PopCards(int count)
    {
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
        int currentCard;
        Card tempCard;
        Random random = new Random();
        
        currentCard = random.Next(_listOfCards.Count);
        SetTrumpCardAndPushToStack(currentCard);
        
        for (int i = 0; i < DECK_COUNT - 1; i++)
        {
            currentCard = random.Next(_listOfCards.Count);
            _stack.Push(_listOfCards[currentCard]);
            _listOfCards.Remove(_listOfCards[currentCard]);
        }

        
    }
    private void SetTrumpCardAndPushToStack(int currentCardIndex)
    {
        var trumpCard = _listOfCards[currentCardIndex].Suit;
        foreach (var card in _listOfCards)
        {
            if(card.Suit == trumpCard)
                card.IsTrumpCard = true;
        }
        _stack.Push(_listOfCards[currentCardIndex]);
        _listOfCards.Remove(_listOfCards[currentCardIndex]); 
    }

}