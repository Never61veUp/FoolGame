using FoolGame.Core.Abstractions;

namespace FoolGame.Core.Model;

public class Player : IPlayer
{
    private ICardCollection _cardCollection;

    private Player(string username, ICardCollection cardCollection)
    {
        Username = username;
        _cardCollection = cardCollection;
    }
    public static Player Create(string playerName, ICardCollection cardCollection)
    {
        return new Player(playerName, cardCollection);

    }

    public string Username { get; private set; }
    public IEnumerable<Card> Cards => _cardCollection.GetAllCards();

    public void AddCards(IEnumerable<Card> cards)
    {
        _cardCollection.AddCards(cards);
    }

    public void RemoveCard(Card card)
    {
        _cardCollection.RemoveCard(card);
    }

    public Card GetHighestCard()
    {
        return _cardCollection.GetHighestCard();
    }

}