using FoolGame.Core.Abstractions;
using FoolGame.Core.Model;

namespace FoolGame.Application.Services;

public class CardCollection : ICardCollection
{
    private readonly List<Card> _cards = [];

    public void AddCards(IEnumerable<Card> cards)
    {
        if (cards == null)
            throw new ArgumentNullException(nameof(cards));

        _cards.AddRange(cards);
    }

    public void RemoveCard(Card card)
    {
        if (card == null)
            throw new ArgumentNullException(nameof(card));

        var cardToRemove = _cards.FirstOrDefault(c => c.Rank == card.Rank && c.Suit == card.Suit);
        if (cardToRemove != null)
        {
            _cards.Remove(cardToRemove);
        }
    }

    public Card GetHighestCard()
    {
        if (!_cards.Any())
            throw new InvalidOperationException("No cards available.");

        return _cards.OrderByDescending(card => card).First();
    }

    public IEnumerable<Card> GetAllCards()
    {
        return _cards.AsReadOnly();
    }
}