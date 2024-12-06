namespace FoolGame.Core.Model;

public class Player
{
    private List<Card> _cards;
    
    public Player(string username)
    {
        Username = username;
        _cards = [];
    }
    public string Username { get; }
    public IEnumerable<Card> Cards => _cards;

    public void AddCards(params Card[] cards)
    {
        _cards.AddRange(cards);
    }

    public void PopCard(Card card)
    {
        _cards.Remove(card);
    }
}