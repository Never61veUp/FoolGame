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

    public void AddCard(params Card[] cards)
    {
        foreach (var card in cards)
        {
            _cards.Add(card);
        }
    }
}