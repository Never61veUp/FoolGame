namespace FoolGame.Core.Model;

public interface IPlayer
{
    string Username { get; }
    IEnumerable<Card> Cards { get; }
    void AddCards(IEnumerable<Card> cards);
    void RemoveCard(Card card);
    Card GetHighestCard();
}