using FoolGame.Core.Model;

namespace FoolGame.Core.Abstractions;

public interface ICardCollection
{ 
        void AddCards(IEnumerable<Card> cards);
        void RemoveCard(Card card);
        Card GetHighestCard();
        IEnumerable<Card> GetAllCards();
}